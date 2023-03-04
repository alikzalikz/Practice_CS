using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder

namespace packt.shared;

public class Northwind : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        
        string connection = $"Filename={path}";
        
        // ConsoleColor previousColor = ForegroundColor;
        // ForegroundColor = ConsoleColor.DarkYellow;
        // WriteLine($"Connection: {connection}");
        // ForegroundColor = previousColor;
        
        optionsBuilder.UseSqlite(connection);

        optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging();
        
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // fluent api
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);
            
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }
}