using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services
{
    internal class CategoryCRUDService : ICRUDService<CategoryDTO>
    {
        private readonly IUnitOfWork _database;

        public CategoryCRUDService(IUnitOfWork database)
        {
            _database = database;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Post(CategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public void Put(CategoryDTO item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
