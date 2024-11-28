namespace DashboardManager.Services;

public interface IService<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    
    // Import/Export
    void ImportFromExcel(string filePath);
    void ImportFromCsv(string filePath);
    void ExportToExcel(string filePath);
    void ExportToCsv(string filePath);
    
    // Sort & Paginate
    IEnumerable<T> GetPaged(int page, int pageSize);
    IEnumerable<T> Sort(string propertyName, bool ascending = true);
}