namespace DashboardManager.Models;

public class Student
{
    
    public int StudentId { get; set; }
    public string StudentName { get; set; }

    // Foreign Key
    public int GradeId { get; set; }
    
    // Navigation property
    public Grade Grade { get; set; }
}