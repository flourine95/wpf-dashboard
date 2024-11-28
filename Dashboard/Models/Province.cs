using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models;

public class Province
{
    [Key]
    public int Id { get; set; } 

    [MaxLength(100)]
    public string Name { get; set; }
    public ICollection<District> Districts { get; set; }
}