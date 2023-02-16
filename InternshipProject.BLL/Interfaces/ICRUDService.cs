namespace InternshipProject.BLL.Interfaces;

public interface ICrudService<T> where T : class
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<T> GetAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task UpdateAsync(T item, int id);
    public Task AddAsync(T item);
    public Task DeleteAsync(int id);
    public void Dispose();
}