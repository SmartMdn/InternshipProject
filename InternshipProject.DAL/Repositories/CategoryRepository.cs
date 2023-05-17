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
            _db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var item = _db.Categories.Find(id);
            if (item != null) _db.Remove(item);
        }

        public IQueryable<Category> Find(Func<Category, bool> predicate)
        {
            return (IQueryable<Category>)_db.Categories.Where(predicate);
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id) ?? throw new InvalidOperationException();
        }

        public IQueryable<Category> GetAll()
        {
            return _db.Categories;
        }

        public IQueryable<Category> GetList(List<int> ids)
        {
            return _db.Categories.Where(t => ids.Contains(t.Id));
        }

        public void Update(Category item)
        {
            var _category = Get(item.Id);
            _category.Name = item.Name;
            _category.Description = item.Description;
            _db.Entry(_category).State = EntityState.Modified;
        }
    }
}
