using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services;

public class SectionCRUDService : ICRUDService<SectionDTO>
{
    private readonly IUnitOfWork _database;

    public SectionCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public SectionDTO Get(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        var section = _database.Sections.Get(id);
        if (section == null)
            throw new ValidationException("Билет не найден", "");
        var ids = (from st in section.Halls select st.Id).ToArray();
        var ids1 = (from st in section.Places select st.Id).ToArray();
        return new SectionDTO { Id = section.Id, Name = section.Name, Halls = ids, Places = ids1};
    }

    public IEnumerable<SectionDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Section, SectionDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Section>, List<SectionDTO>>(_database.Sections.GetAll());
    }

    public void Put(SectionDTO item, int id)
    {
        if (item == null) return;
        var section = new Section
        {
            Id = id, 
            Name = item.Name,
            Halls = _database.Halls.GetList(item.Halls.ToList()).ToList(),
            Places = _database.Places.GetList(item.Places.ToList()).ToList()
        };
        _database.Sections.Update(section);
        _database.Save();
    }

    public void Post(SectionDTO item)
    {
        if (item == null) return;
        var section = new Section()
        {
            Name = item.Name,
            Halls = _database.Halls.GetList(item.Halls.ToList()).ToList(),
            Places = _database.Places.GetList(item.Places.ToList()).ToList()
        };
        _database.Sections.Create(section);
        _database.Save();
    }

    public void Delete(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        _database.Sections.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}