namespace InternshipProject.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    /// <summary>
    ///     Получаение всех строк таблицы из базы данных
    /// </summary>
    /// <returns><c>IEnumerable</c>, состоящий из строк таблицы</returns>
    Task<IQueryable<T>> GetAllAsync();
    Task<IQueryable<T>> GetListAsync(List<int> ids);
    Task<T> GetAsync(int id);
    Task<IQueryable<T>> FindAsync(Func<T, bool> predicate);
    Task CreateAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(int id);
}