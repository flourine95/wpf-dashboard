using DashboardManager.Models;

namespace DashboardManager.Repositories;

public class ProductRepository :GenericRepository<Product>
{
    public ProductRepository(AppDbContext context) : base(context)
    {
        
    }
}