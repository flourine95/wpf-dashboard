using System.Diagnostics;
using System.Windows;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Services;

public class UserService
{
    private readonly AppDbContext _context;


    public UserService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<User>> GetAllUsers()
    {
        try
        {
            return await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            // Log lỗi (tùy chọn)
            Console.WriteLine($"Error fetching users: {ex.Message}");
            return [];
        }
    }

    public async Task<bool> AddUserAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            Debug.WriteLine($"Database update error: {ex.Message}");
            if (ex.InnerException != null)
            {
                Debug.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unexpected error: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Database update error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> SaveUserAsync(User user)
    {
        try
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                // Thêm người dùng mới
                _context.Users.Add(user);
            }
            else
            {
                // Cập nhật thông tin người dùng
                _context.Entry(existingUser).CurrentValues.SetValues(user);
            }

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving user: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        try
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Database delete error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            return false;
        }
    }

    public async Task<List<User>> GetUsersPagedAsync(int pageNumber, int pageSize)
    {
        try
        {
            return await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching paginated users: {ex.Message}");
            return new List<User>();
        }
    }
}