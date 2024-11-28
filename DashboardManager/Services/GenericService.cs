using System.IO;
using DashboardManager.Repositories;
using OfficeOpenXml;

namespace DashboardManager.Services;

public class GenericService<T> : IService<T> where T : class
{
    protected readonly IRepository<T> _repository;
    
    public GenericService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public IEnumerable<T> GetAll()
    {
        return _repository.GetAll();
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Add(T entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }

    public void Update(T entity)
    {
        _repository.Update(entity);
        _repository.SaveChanges();
    }

    public void Delete(T entity)
    {
        _repository.Delete(entity);
        _repository.SaveChanges();
    }

    public void ImportFromExcel(string filePath)
    {
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            // Implement Excel import logic
        }
    }

    public void ImportFromCsv(string filePath)
    {
        throw new NotImplementedException();
    }

    public void ExportToExcel(string filePath)
    {
        try
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
            var data = _repository.GetAll().ToList();
            
            // Add headers
            var properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = properties[i].Name;
            }

            // Add data
            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = 
                        properties[col].GetValue(data[row]);
                }
            }

            package.SaveAs(new FileInfo(filePath));
        }
        catch (Exception ex)
        {
            // Log error
            throw;
        }
    }

    public void ExportToCsv(string filePath)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetPaged(int page, int pageSize)
    {
        return _repository.GetPaged(page, pageSize);
    }

    public IEnumerable<T> Sort(string propertyName, bool ascending = true)
    {
        return _repository.Sort(propertyName, ascending);
    }
}