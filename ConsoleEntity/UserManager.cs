using ConsoleEntity.Models;

namespace ConsoleEntity;

public class UserManager
{
    private readonly AppDbContext _context = new();

    public void CreateUser(string? name, string? email, string? password, int role = 0)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("All fields are required.");
            return;
        }

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password,
            Role = role,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        Console.WriteLine("User created successfully.");
    }

    public void ReadUsers()
    {
        var users = _context.Users.ToList();

        if (users.Count != 0)
        {
            Console.WriteLine("\n--- List of Users ---");
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
            }
        }
        else
        {
            Console.WriteLine("No users found.");
        }
    }

    public void UpdateUser(int id, string? name, string? email, string? password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            if (!string.IsNullOrEmpty(name)) user.Name = name;
            if (!string.IsNullOrEmpty(email)) user.Email = email;
            if (!string.IsNullOrEmpty(password)) user.Password = password;
            user.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}