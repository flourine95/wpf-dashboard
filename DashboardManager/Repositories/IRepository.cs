namespace DashboardManager.Repositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void SaveChanges();
    
    IEnumerable<T> GetPaged(int page, int pageSize);
    IEnumerable<T> Sort(string propertyName, bool ascending);
}