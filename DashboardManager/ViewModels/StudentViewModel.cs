using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using DashboardManager.Commands;
using DashboardManager.Models;
using DashboardManager.Services;
using Microsoft.EntityFrameworkCore;

namespace DashboardManager.ViewModels;

public class StudentViewModel : BaseViewModel
{
    private readonly IService<Student> _studentService;
    public ObservableCollection<Student> Students { get; set; }
    private Student _selectedStudent;
    public Student SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            _selectedStudent = value;
            OnPropertyChanged(nameof(SelectedStudent));
        }
    }

    // Commands
    public ICommand AddStudentCommand { get; private set; }
    public ICommand RemoveStudentCommand { get; private set; }
    public ICommand EditStudentCommand { get; private set; }

    public StudentViewModel(IService<Student> studentService)
    {
        _studentService = studentService;
        Students = new ObservableCollection<Student>();
        InitializeCommands();
        LoadStudents();
    }

    private void InitializeCommands()
    {
        AddStudentCommand = new RelayCommand(ExecuteAdd, CanExecuteAdd);
        RemoveStudentCommand = new RelayCommand(ExecuteRemove, CanExecuteRemove);
        EditStudentCommand = new RelayCommand(ExecuteEdit, CanExecuteEdit);
    }

    private void LoadStudents()
    {
        var students = _studentService.GetAll();
        Students = new ObservableCollection<Student>(students);
        OnPropertyChanged(nameof(Students));
    }

    private bool CanExecuteAdd() => true;
    private void ExecuteAdd()
    {
        var student = new Student(); // Add properties initialization
        _studentService.Add(student);
        Students.Add(student);
    }

    private bool CanExecuteRemove() => SelectedStudent != null;
    private void ExecuteRemove()
    {
        if (SelectedStudent != null)
        {
            _studentService.Delete(SelectedStudent);
            Students.Remove(SelectedStudent);
        }
    }

    private bool CanExecuteEdit() => SelectedStudent != null;
    private void ExecuteEdit()
    {
        if (SelectedStudent != null)
        {
            _studentService.Update(SelectedStudent);
        }
    }
}