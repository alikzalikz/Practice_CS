using System.Security.AccessControl;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

partial class Program
{
    static void FilterAndSort()
    {
        SectionTitle("Filter And Sort");

        using (Northwind db = new())
        {
            DbSet<Product> allProducts = db.Products;

            IQueryable<Product> processedProducts = allProducts.ProcessSequence();

            IQueryable<Product> filteredProducts = processedProducts
                .Where(product => product.UnitPrice < 10M);

            IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts
                .OrderByDescending(product => product.UnitPrice);

            // WriteLine(sortedAndFilteredProducts.ToQueryString());
            /*
                SELECT "p"."ProductId", "p"."CategoryId", "p"."Discontinued", "p"."ProductName", "p"."QuantityPerUnit", "p"."ReorderLevel", "p"."SupplierId", "p"."UnitPrice", "p"."UnitsInStock", "p"."UnitsOnOrder"
                FROM "Products" AS "p"
                WHERE "p"."UnitPrice" < 10.0
                ORDER BY "p"."UnitPrice" DESC
            */

            var ProjectedProducts = sortedAndFilteredProducts
                .Select(product => new
                {
                    product.ProductId,
                    product.ProductName,
                    product.UnitPrice
                });

            // WriteLine(ProjectedProducts.ToQueryString());
            /* 
                SELECT "p"."ProductId", "p"."ProductName", "p"."UnitPrice"
                FROM "Products" AS "p"
                WHERE "p"."UnitPrice" < 10.0
                ORDER BY "p"."UnitPrice" DESC
            */
            WriteLine("Products that cost less than $10");

            foreach (var p in ProjectedProducts)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}",
                    p.ProductId, p.ProductName, p.UnitPrice);
            }
            WriteLine();
        }
    }

    static void JoinCategoriesAndProducts()
    {
        SectionTitle("join categories and prudocts");

        using (Northwind db = new())
        {
            var queryJoin = db.Categories.Join(
                inner: db.Products,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.ProductId,
                resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId })
                .OrderBy(cp => cp.CategoryName);

            foreach (var item in queryJoin)
            {
                WriteLine("{0}: {1} is in {2}.",
                        item.ProductId,
                        item.ProductName,
                    arg2: item.CategoryName
                );
            }

        }
    }

    static void GroupJoinCategoriesAndProducts()
    {
        SectionTitle("GroupJoinCategoriesAndProducts");

        using (Northwind db = new())
        {
            var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                inner: db.Products,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.ProductId,
                resultSelector: (c, matchingProducts) => new
                {
                    c.CategoryName,
                    Product = matchingProducts.OrderBy(p => p.ProductName)
                }
            );

            foreach (var category in queryGroup)
            {
                WriteLine("{0} has {1} products",
                    category.CategoryName,
                    category.Product.Count());

                foreach (var product in category.Product)
                {
                    WriteLine($"    {product.ProductName}");
                }
            }
        }

    }

    static void AggregateProducts()
    {
        SectionTitle("Aggregate Products");

        using (Northwind db = new())
        {
            if (db.Products.TryGetNonEnumeratedCount(out int countDbSet))
            {
                WriteLine("{0,-25} {1,10}",
                    "Products count from DbSet",
                    countDbSet);
            }
            else
            {
                WriteLine("Products DbSet does not have a count property.");
            }

            List<Product> products = db.Products.ToList();

            if (products.TryGetNonEnumeratedCount(out int countList))
            {
                WriteLine("{0,-25} {1,10}",
                    "Products count from list",
                    countList);
            }
            else
            {
                WriteLine("Products list does not have count property");
            }

            WriteLine("{0,-25} {1,10}",
                "Product count:",
                db.Products.Count());
            
            WriteLine("{0,-27} {1,8}",
                "Discontinued product count:",
                db.Products.Count(product => product.Discontinued));
            
            WriteLine("{0,-25} {1,10:$#,##0.00}",
                "Highest product price:",
                db.Products.Max(p => p.UnitPrice));
            
            WriteLine("{0,-25} {1,10:N0}",
                "Sum of units in stock:",
                db.Products.Sum(p => p.UnitsInStock));
            
            WriteLine("{0,-25} {1,10:N0}",
                "Sum of units on order:",
                db.Products.Sum(p => p.UnitsOnOrder));
            
            WriteLine("{0,-25} {1,10:$#,##0.00}",
                "Average unit price:",
                db.Products.Average(p => p.UnitPrice));
            
            WriteLine("{0,-25} {1,10:$#,##0.00}",
                "Value of units in stock:",
                db.Products.Sum(p => p.UnitPrice * p.UnitsInStock));
        }
    }

    static void OutputTableOfProducts(Product[] products, int currentPage, int totalPage)
    {
        string line = new('-', count: 73);
        string lineHalf = new('-', count: 30);

        WriteLine(line);
        WriteLine("{0,4} {1,-40} {2,12} {3,-15}",
            "ID", "Product Name", "Unit Price", "Discontinued");
        WriteLine(line);

        foreach (Product p in products)
        {
            WriteLine("{0,4} {1,-40} {2,12:c} {3,-15}",
                p.ProductId, p.ProductName, p.UnitPrice, p.Discontinued);
        }
        WriteLine("{0} Page {1} of {2} {3}",
            lineHalf, currentPage + 1, totalPage + 1, lineHalf);
    }

    static void OutputPageOfProducts(IQueryable<Product> products, int pageSize, int currentPage, int totalPage)
    {
        var pagingQuery = products
            .OrderBy(p => p.ProductId)
            .Skip(currentPage * pageSize)
            .Take(pageSize);
        
        SectionTitle(pagingQuery.ToQueryString());

        OutputTableOfProducts(pagingQuery.ToArray(), currentPage, totalPage);
    }

    static void PagingProducts()
    {
        // SectionTitle("Paging Products");

        using (Northwind db = new())
        {
            int pageSize = 10;
            int currentPage = 0;
            int productsCount = db.Products.Count();
            int totalPage = productsCount / pageSize;

            while(true)
            {
                OutputPageOfProducts(db.Products, pageSize, currentPage, totalPage);

                Write("Press <- to page back, press -> to page forward, Esc to exit.");
                ConsoleKey key = ReadKey().Key;

                if (key == ConsoleKey.LeftArrow)
                    if (currentPage == 0)
                        currentPage = totalPage;
                    else
                        currentPage--;
                else if (key == ConsoleKey.RightArrow)
                    if (currentPage == totalPage)
                        currentPage = 0;
                    else
                        currentPage++;
                else if (key == ConsoleKey.Escape)
                    break;

                Clear();
            }
        }
    }

    static void CustomExtensionMethods()
    {
        SectionTitle("Custom aggregate extension methods");

        using (Northwind db = new())
        {
            WriteLine("{0,-25} {1,10:N0}",
                "Mean units in stock:",
                db.Products.Average(p => p.UnitsInStock));

            WriteLine("{0,-25} {1,10:$#,##0.00}",
                "Mean unit price:",
                db.Products.Average(p => p.UnitPrice));

            WriteLine("{0,-25} {1,10:N0}",
                "Median units in stock:",
                db.Products.Median(p => p.UnitsInStock));

            WriteLine("{0,-25} {1,10:$#,##0.00}",
                "Median unit price:",
                db.Products.Median(p => p.UnitPrice));

            WriteLine("{0,-25} {1,10:N0}",
                "Mode units in stock:",
                db.Products.Mode(p => p.UnitsInStock));

            WriteLine("{0,-25} {1,10:$#,##0.00}",
                "Mode unit price:",
                db.Products.Mode(p => p.UnitPrice));
        }
    }

    static void OutputProductsAsXml()
    {
        SectionTitle("Output products as XML");

        using (Northwind db = new())
        {
            Product[] productsArray = db.Products.ToArray();

            XElement xml = new("products",
                from p in productsArray
                select new XElement("product",
                    new XAttribute("id", p.ProductId),
                    new XAttribute("price", p.UnitPrice),
                    new XElement("name", p.ProductName)));
            WriteLine(xml.ToString());
        }
    }

    static void ProcessSettings()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "settings.xml");
        WriteLine($"Settings file path: {path}");

        XDocument doc = XDocument.Load(path);
        var appSettings = doc.Descendants("appSettings")
            .Descendants("add")
            .Select(node => new
            {
                Key = node.Attribute("key")?.Value,
                Value = node.Attribute("value")?.Value
            }).ToArray();
        
        foreach (var item in appSettings)
        {
            WriteLine($"{item.Key}: {item.Value}");
        }
    }
}