using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories
{
    internal class CategoryRepository : IRepository<Category>
    {
        private readonly CinemaContext _db;

        public CategoryRepository(CinemaContext db)
        {
            _db = db;
        }

        public void Create(Category item)
        {
            _ = _db.Categories.Add(item);
        }

        public void Delete(int? id)
        {
            Category? item = _db.Categories.Find(id);
            if (item != null)
            {
                _ = _db.Remove(item);
            }
        }

        public IQueryable<Category> Find(Func<Category, bool> predicate)
        {
            return (IQueryable<Category>)_db.Categories.Include(c => c.Events).Where(predicate);
        }

        public Category Get(int? id)
        {
            return _db.Categories.Include(c => c.Events).FirstOrDefault(c => c.Id == id) ?? throw new InvalidOperationException();
        }

        public IQueryable<Category> GetAll()
        {
            return _db.Categories;
        }

        public IQueryable<Category> GetList(List<int> ids)
        {
            return _db.Categories.Include(e => e.Events).Where(t => ids.Contains(t.Id));
        }

        public void Update(Category item)
        {
            Category _category = Get(item.Id);
            _category.Name = item.Name;
            _category.Description = item.Description;
            _category.Events = item.Events;
            _db.Entry(_category).State = EntityState.Modified;
        }
    }
}
