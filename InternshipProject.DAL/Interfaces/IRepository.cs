namespace InternshipProject.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    /// <summary>
    ///     Получаение всех строк таблицы из базы данных
    /// </summary>
    /// <returns><c>IEnumerable</c>, состоящий из строк таблицы</returns>
    IQueryable<T> GetAll();

    IQueryable<T> GetList(List<int> ids);
    T Get(int id);
    IQueryable<T> Find(Func<T, bool> predicate);
    void Create(T item);
    void Update(T item);
    void Delete(int id);
}