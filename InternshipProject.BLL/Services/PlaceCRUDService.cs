using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services;

public class PlaceCRUDService : ICRUDService<PlaceDTO>
{
    private readonly IUnitOfWork _database;

    public PlaceCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public PlaceDTO Get(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        var place = _database.Places.Get(id);
        if (place == null)
            throw new ValidationException("Билет не найден", "");
        var ids = from st in place.Sections select st.Id;
        return new PlaceDTO { Id = place.Id, Type = (int)place.Type, Sections = ids.ToArray()};
    }

    public IEnumerable<PlaceDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(_database.Places.GetAll());
    }

    public void Put(PlaceDTO item, int id)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, Place>()).CreateMapper();
        var place = mapper.Map<PlaceDTO, Place>(item);
        _database.Places.Update(place);
        if (item.Sections != null) place.Sections = _database.Sections.GetList(item.Sections.ToList()).ToList();
        place.Id = id;
        _database.Save();
    }

    public void Post(PlaceDTO item)
    {
        //TODO дофиксить методы пост и пут для всех сущностей
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, Place>()).CreateMapper();
        var place = mapper.Map<PlaceDTO, Place>(item);
        if (item.Sections != null) place.Sections = _database.Sections.GetList(item.Sections.ToList()).ToList();
        _database.Places.Create(place);
        _database.Save();
    }

    public void Delete(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        _database.Places.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}