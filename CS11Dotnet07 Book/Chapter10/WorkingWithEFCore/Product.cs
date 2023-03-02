using System.ComponentModel.DataAnnotations; // [Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace packt.shared;

public class Product
{
    public int ProductId { get; set; }
    
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;
    
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }
    
    [Column("UnitsInStock")]
    public short? Stock { get; set; }
    
    public bool Discontinued { get; set; }

    public int CategoryId { get; set; }
    
    public virtual Category Category { get; set; } = null!;
}