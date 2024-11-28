using DashboardManager.Models;
using DashboardManager.Repositories;

namespace DashboardManager.Services;

public class ProductService : GenericService<Product>
{
    public ProductService(IRepository<Product> repository) : base(repository)
    {
        
    }
}