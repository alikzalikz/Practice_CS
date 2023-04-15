using Packt.Shared; // AddNorthwindContext()

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();
builder.Services.AddRequestDecompression();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }

    if (context.Request.Path == "/bonjour")
    {
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    await next();
});

app.UseHttpsRedirection();
app.UseRequestDecompression();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapRazorPages();
app.MapGet("/hello", () => "Hello World!");

app.Run();

WriteLine("This executes after the web server has stopped!");