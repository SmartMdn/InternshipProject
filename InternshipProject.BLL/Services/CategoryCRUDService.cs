using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services
{
    internal class CategoryCRUDService : ICRUDService<CategoryDTO>
    {
        private readonly IUnitOfWork _database;

        public CategoryCRUDService(IUnitOfWork database)
        {
            _database = database;
        }

        public CategoryDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id билета", "");
            }

            Category category = _database.Categories.Get(id);
            if (category == null)
            {
                throw new ValidationException("Билет не найден", "");
            }

            int[] ids = (from st in category.Events select st.Id).ToArray();
            return new CategoryDTO { Id = category.Id, Description = category.Description, Name = category.Name, Events = ids };
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stadium, StadiumDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(_database.Categories.GetAll());
        }

        public void Put(CategoryDTO item, int? id)
        {
            if (item == null)
            {
                return;
            }

            Category category = new() { Id = (int)id, Name = item.Name, Description = item.Description, Events = _database.Events.GetList(item.Events.ToList()).ToList() };
            _database.Categories.Update(category);
            _database.Save();
        }

        public void Post(CategoryDTO item)
        {
            if (item == null)
            {
                return;
            }

            Category category = new() { Name = item.Name, Description = item.Description, Events = _database.Events.GetList(item.Events.ToList()).ToList() };
            _database.Categories.Create(category);
            _database.Save();
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id билета", "");
            }

            _database.Categories.Delete(id);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
