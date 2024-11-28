namespace DashboardManager.Models;

public class Grade
{
    public int GradeId { get; set; }
    public string GradeName { get; set; }
    
    // One-to-Many relationship
    public ICollection<Student> Students { get; set; }
}