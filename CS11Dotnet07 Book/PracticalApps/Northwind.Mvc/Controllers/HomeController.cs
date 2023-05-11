using System.Diagnostics; // Activity
using Microsoft.AspNetCore.Mvc; // Controller, IActionResult
using Northwind.Mvc.Models; // ErrorViewModel
using Packt.Shared; // NorthwindContext
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext db;

    public HomeController(ILogger<HomeController> logger, NorthwindContext injectedContext)
    {
        _logger = logger;
        db = injectedContext;
    }

    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
    public IActionResult Index()
    {
        HomeIndexViewModel model = new
        (
            VisitorCount: Random.Shared.Next(1, 1001),
            Categories: db.Categories.ToList(),
            Products: db.Products.ToList()
        );

        return View(model);
    }

    [Route("private")]
    [Authorize(Roles = "Adminstrator")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
    {
        ViewData["alertstyle"] = alertstyle;

        if (!id.HasValue)
        {
            return BadRequest("You must pass a product ID in the route, for\r\n example, /Home/ProductDetail/21");
        }

        Product? model = db.Products
            .SingleOrDefault(p => p.ProductId == id);

        if (model is null)
        {
            return NotFound($"Product {id} not found");
        }

        return View(model);
    }

    public IActionResult ModelBinding()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ModelBinding(Thing thing)
    {
        HomeModelBindingViewModel model = new(
            Thing: thing,
            HasError: !ModelState.IsValid,
            ValidationErrors: ModelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage)
        );

        return View(model);
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price)
    {
        if (!price.HasValue)
        {
            return BadRequest("You must pass a product price in the query string,\r\n for example, /Home/ProductsThatCostMoreThan?price=50");

        }
            
        IEnumerable<Product> model = db.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => p.UnitPrice > price);

        if (!model.Any())
        {
            return NotFound($"no products cost more than {price:C}.");
        }

        ViewData["MaxPrice"] = price.Value.ToString("C");

        return View(model);
    }
}
