using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models;

public class Order
{
    [Key] public int Id { get; set; } 

    [ForeignKey("User")] public int? UserId { get; set; } 

    [Column(TypeName = "decimal(10, 2)")] public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus Status { get; set; } 

    public string Address { get; set; }

    [ForeignKey("Province")] public int ProvinceId { get; set; }

    [ForeignKey("District")] public int DistrictId { get; set; }

    [ForeignKey("Ward")] public int WardId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Province Province { get; set; }
    public virtual District District { get; set; }
    public virtual Ward Ward { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}

public enum OrderStatus
{
    Pending = 0, // Trạng thái chờ
    Completed = 1, // Trạng thái hoàn thành
    Canceled = 2, // Trạng thái hủy
    Shipped = 3, // Trạng thái đã gửi (nếu cần)
}