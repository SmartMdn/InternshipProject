using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class PlaceCRUDService : ICRUDService<PlaceDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public PlaceCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public PlaceDTO Get(int id)
    {
        var place = _unitOfWork.Places.GetAsync(id).Result;
        if (place == null)
            throw new ValidationException("Билет не найден", "");
        return new PlaceDTO { Id = place.Id, Type = place.Type};
    }

    public IEnumerable<PlaceDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(_unitOfWork.Places.GetAllAsync().Result);
    }

    public void Put(PlaceDTO item, int id)
    {
        var place = new Place
        {
            Id = id, 
            Type = item.Type
        };
        _unitOfWork.Places.UpdateAsync(place);
        _unitOfWork.Save();
    }

    public void Post(PlaceDTO item)
    {
        var place = new Place
        {
            Type = item.Type
        };
        _unitOfWork.Places.CreateAsync(place);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _unitOfWork.Places.DeleteAsync(id);
        _unitOfWork.Save();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}