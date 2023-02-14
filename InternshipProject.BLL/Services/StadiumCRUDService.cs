using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class StadiumCRUDService : ICRUDService<StadiumDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public StadiumCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public StadiumDTO Get(int id)
    {
        var stadium = _unitOfWork.Stadiums.Get(id);
        if (stadium == null)
            throw new ValidationException("Билет не найден", "");
        var ids = (from st in stadium.Halls select st.Id).ToArray();
        return new StadiumDTO { Id =stadium.Id , Address = stadium.Address, Name = stadium.Name, Halls = ids};
    }

    public IEnumerable<StadiumDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stadium, StadiumDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Stadium>, List<StadiumDTO>>(_unitOfWork.Stadiums.GetAll());
    }

    public void Put(StadiumDTO item, int id)
    {
        var stadium = new Stadium
        {
            Id = id,
            Address = item.Address, 
            Halls = _unitOfWork.Halls.GetList(item.Halls!.ToList()).ToList(),
            Name = item.Name
        };
        _unitOfWork.Stadiums.Update(stadium);
        _unitOfWork.Save();
    }

    public void Post(StadiumDTO item)
    {
        if (_unitOfWork.Stadiums.GetAll().Any(o => o.Name == item.Name || o.Address == item.Name))
        {
            return;
        }
        var stadium = new Stadium
        {
            Address = item.Address,
            Halls = _unitOfWork.Halls.GetList(item.Halls!.ToList()).ToList(), 
            Name = item.Name
        };
        _unitOfWork.Stadiums.Create(stadium);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _unitOfWork.Stadiums.Delete(id);
        _unitOfWork.Save();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}