using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models;

public class District
{
    [Key]
    public int Id { get; set; } 

    [MaxLength(100)]
    public string Name { get; set; }

    [ForeignKey("Province")]
    public int ProvinceId { get; set; } 

    // Navigation property
    public virtual Province Province { get; set; }
    public ICollection<Ward> Wards { get; set; }
}