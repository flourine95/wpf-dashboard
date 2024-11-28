using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models;

public class Ward
{
    [Key]
    public int Id { get; set; } 

    [MaxLength(100)]
    public string Name { get; set; }

    [ForeignKey("District")]
    public int DistrictId { get; set; } 

    // Navigation property
    public virtual District District { get; set; }
}