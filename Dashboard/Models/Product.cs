using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models;

public class Product
{
    [Key] public int Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")] public decimal Price { get; set; }

    public int Stock { get; set; }

    public int View { get; set; }

    public string Image { get; set; }

    [ForeignKey("Category")] public int CategoryId { get; set; }

    [ForeignKey("Brand")] public int BrandId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public virtual Category Category { get; set; }
    public virtual Brand Brand { get; set; }
}