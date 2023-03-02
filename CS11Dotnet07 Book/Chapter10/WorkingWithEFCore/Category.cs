using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace packt.shared;

public class Category
{
    public int CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
    
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }
    
    public Category()
    {
        Products = new HashSet<Product>();
    }
}