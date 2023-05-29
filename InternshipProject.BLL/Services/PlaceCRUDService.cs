using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class PlaceCRUDService : ICRUDService<PlaceDTO>
{
    private readonly IUnitOfWork _database;

    public PlaceCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public PlaceDTO Get(int? id)
    {
        if (id == null)
        {
            throw new ValidationException("Не установлен id билета", "");
        }

        Place place = _database.Places.Get(id);
        return place == null ? throw new ValidationException("Билет не найден", "") : new PlaceDTO { Id = place.Id, Type = place.Type };
    }

    public IEnumerable<PlaceDTO> GetAll()
    {
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(_database.Places.GetAll());
    }

    public void Put(PlaceDTO item, int? id)
    {
        if (item == null)
        {
            return;
        }

        Place place = new()
        {
            Id = (int)id,
            Type = item.Type
        };
        _database.Places.Update(place);
        _database.Save();
    }

    public void Post(PlaceDTO item)
    {
        if (item == null)
        {
            return;
        }

        Place place = new()
        {
            Type = item.Type
        };
        _database.Places.Create(place);
        _database.Save();
    }

    public void Delete(int? id)
    {
        if (id == null)
        {
            throw new ValidationException("Не установлен id билета", "");
        }

        _database.Places.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}