namespace InternshipProject.BLL.Interfaces;

public interface ICRUDService<T> where T : class
{
    public T Get(int? id);
    public IEnumerable<T> GetAll();
    public void Put(T item, int? id);
    public void Post(T item);
    public void Delete(int? id);
    public void Dispose();
}