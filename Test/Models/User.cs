using System.ComponentModel.DataAnnotations;

namespace Test.Models;

public class User
{
    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(50, ErrorMessage = "Tên phải dưới 50 ký tự")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Password không được để trống trong model.")]
    [MinLength(8, ErrorMessage = "Password phải tối thiểu 8 ký tự trong model.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }
}