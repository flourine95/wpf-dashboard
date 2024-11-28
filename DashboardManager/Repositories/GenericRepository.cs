using System.Linq.Expressions;
using DashboardManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardManager.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public IEnumerable<T> GetPaged(int page, int pageSize)
    {
        return _dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public IEnumerable<T> Sort(string propertyName, bool ascending)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

        return ascending
            ? _dbSet.OrderBy(lambda).ToList()
            : _dbSet.OrderByDescending(lambda).ToList();
    }
}