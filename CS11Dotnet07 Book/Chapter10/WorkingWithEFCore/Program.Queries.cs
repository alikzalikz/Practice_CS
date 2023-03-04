using Microsoft.EntityFrameworkCore; // Include
using Microsoft.EntityFrameworkCore.ChangeTracking; // CollectionEntry
using packt.shared; // Northwind, Product, Category

partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            SectionTitle("Categories and how many products they have:");

            IQueryable<Category>? categories;
                //  = db.Categories;
                // .Include(c => c.Products);

            db.ChangeTracker.LazyLoadingEnabled = false;

            Write("Enable eager loading? (Y/N): ");
            bool eagerLoading = (ReadKey(intercept: true).Key == ConsoleKey.Y);
            bool explicitLoading = false;
            WriteLine();

            if (eagerLoading)
            {
                categories = db.Categories?.Include(c => c.Products);
            }
            else
            {
                categories = db.Categories;
                Write("Enable explicit loading? (Y/N): ");
                explicitLoading = (ReadKey(intercept: true).Key == ConsoleKey.Y);
                WriteLine();
            }

            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found.");
                return;
            }

            foreach (Category c in categories)
            {
                if (explicitLoading)
                {
                    Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                    ConsoleKeyInfo key = ReadKey(intercept: true);
                    WriteLine();

                    if (key.Key == ConsoleKey.Y)
                    {
                        CollectionEntry<Category, Product> products =
                            db.Entry(c).Collection(c2 => c2.Products);
                        if (!products.IsLoaded) products.Load();
                    }
                }
                
                WriteLine($"{c.CategoryName} has {c.Products.Count} products");
            }
        }
    }

    static void FilteredIncludes()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products with a minimum number of units in stock.");
            
            string? input;
            int stock;
            
            do
            {
                Write("Enter a minimum for units in stock: ");
                input = ReadLine();
            } while (!int.TryParse(input, out stock));
            
            IQueryable<Category>? categories = db.Categories?
                .Include(c => c.Products.Where(p => p.Stock >= stock));
            
            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found.");
                return;
            }
            
            Info($"ToQueryString: {categories.ToQueryString()}");
            /*
                Info > ToQueryString: .param set @__stock_0 99

                SELECT "c"."CategoryId", "c"."CategoryName", "c"."Description", "t"."ProductId", "t"."CategoryId", "t"."UnitPrice", "t"."Discontinued", "t"."ProductName", "t"."UnitsInStock"
                FROM "Categories" AS "c"
                LEFT JOIN (
                    SELECT "p"."ProductId", "p"."CategoryId", "p"."UnitPrice", "p"."Discontinued", "p"."ProductName", "p"."UnitsInStock"
                    FROM "Products" AS "p"
                    WHERE "p"."UnitsInStock" >= @__stock_0
                ) AS "t" ON "c"."CategoryId" = "t"."CategoryId"
                ORDER BY "c"."CategoryId"
            */

            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
                
                foreach(Product p in c.Products)
                {
                    WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
                }
            }
        }
    }

    static void QueryingProducts()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products that cost more than a price, highest at top.");
            
            string? input;
            decimal price;
            
            do
            {
                Write("Enter a product price: ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));
            
            IQueryable<Product>? products = db.Products?
                // .TagWith("Products filtered by price and sorted.")
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);
            
            if ((products is null) || (!products.Any()))
            {
                Fail("No products found.");
                return;
            }
            
            Info($"ToQueryString: {products.ToQueryString()}");
            /*
                Info > ToQueryString: .param set @__price_0 50.0

                SELECT "p"."ProductId", "p"."CategoryId", "p"."UnitPrice", "p"."Discontinued", "p"."ProductName", "p"."UnitsInStock"
                FROM "Products" AS "p"
                WHERE "p"."UnitPrice" > @__price_0
                ORDER BY "p"."UnitPrice" DESC
            */
            
            foreach (Product p in products)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
                    p.ProductId, p.ProductName, p.Cost, p.Stock);
            }
        }        
    }

    static void QueryingWithLike()
    {
        using (Northwind db = new())
        {
            SectionTitle("Pattern matching with LIKE.");
            
            Write("Enter part of a product name: ");
            string? input = ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Fail("You did not enter part of a product name.");
                return;
            }
            
            IQueryable<Product>? products = db.Products?
                .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
            
            if ((products is null) || (!products.Any()))
            {
                Fail("No products found.");
                return;
            }
            
            foreach (Product p in products)
            {
                WriteLine("{0} has {1} units in stock. Discontinued? {2}",
                    p.ProductName, p.Stock, p.Discontinued);
            }
        }
    }

    static void  GetRandomProduct()
    {
        using (Northwind db = new())
        {
            SectionTitle("get a random product");

            int? rowCount = db.Products?.Count();

            if (rowCount is null)
            {
                WriteLine("product table is empty.");
                return;
            }

            Product? p  = db.Products?.FirstOrDefault(
                p => p.ProductId == (int)(EF.Functions.Random() * rowCount));

            if (p is null)
            {
                WriteLine("product not found");
                return;
            }

            WriteLine($"random product: {p.ProductId} {p.ProductName}");
        }
    }
}