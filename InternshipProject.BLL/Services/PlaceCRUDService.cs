using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class PlaceCRUDService : ICrudService<PlaceDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public PlaceCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PlaceDTO> GetAsync(int id)
    {
        var place = await _unitOfWork.Places.GetAsync(id);
        if (place == null)
            throw new ValidationException("Билет не найден", "");
        return new PlaceDTO { Id = place.Id, Type = place.Type};
    }

    public async Task<IEnumerable<PlaceDTO>> GetAllAsync()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(await _unitOfWork.Places.GetAllAsync());
    }

    public async Task UpdateAsync(PlaceDTO item, int id)
    {
        var place = new Place
        {
            Id = id, 
            Type = item.Type
        };
        await _unitOfWork.Places.UpdateAsync(place);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddAsync(PlaceDTO item)
    {
        var place = new Place
        {
            Type = item.Type
        };
        await _unitOfWork.Places.CreateAsync(place);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Places.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}