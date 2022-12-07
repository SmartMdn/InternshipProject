using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services;

public class StadiumCRUDService : ICRUDService<StadiumDTO>
{
    private readonly IUnitOfWork _database;

    public StadiumCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public StadiumDTO Get(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        var stadium = _database.Stadiums.Get(id);
        if (stadium == null)
            throw new ValidationException("Билет не найден", "");
        var ids = (from st in stadium.Halls select st.Id).ToArray();
        return new StadiumDTO { Address = stadium.Address, Name = stadium.Name, Halls = ids};
    }

    public IEnumerable<StadiumDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stadium, StadiumDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Stadium>, List<StadiumDTO>>(_database.Stadiums.GetAll());
    }

    public void Put(StadiumDTO item, int id)
    {
        if (item == null) return;
        var stadium = new Stadium{Address = item.Address, Halls = _database.Halls.GetList(item.Halls.ToList()).ToList(), Id = id, Name = item.Name};
        _database.Stadiums.Update(stadium);
        _database.Save();
    }

    public void Post(StadiumDTO item)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StadiumDTO, Stadium>()).CreateMapper();
        var stadium = mapper.Map<StadiumDTO, Stadium>(item);
        if (item.Halls != null) stadium.Halls = _database.Halls.GetList(item.Halls.ToList()).ToList();
        _database.Stadiums.Create(stadium);
        _database.Save();
    }

    public void Delete(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        _database.Stadiums.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}