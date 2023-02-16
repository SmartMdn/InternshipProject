using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class HallCRUDService : ICrudService<HallDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public HallCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<HallDTO> GetAsync(int id)
    {
        var hall = await _unitOfWork.Halls.GetAsync(id);
        if (hall == null)
            throw new ValidationException("Билет не найден", "");
        return new HallDTO { Id = hall.Id, Name = hall.Name};
    }

    public async Task<IEnumerable<HallDTO>> GetAllAsync()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hall, HallDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Hall>, List<HallDTO>>( await _unitOfWork.Halls.GetAllAsync());
    }

    public async Task UpdateAsync(HallDTO item, int id)
    {
        var hall = new Hall
        {
            Id = id,
            Name = item.Name,
            Sections = _unitOfWork.Sections.GetListAsync(item.Sections!.ToList()).Result.ToList()
        };
        await _unitOfWork.Halls.UpdateAsync(hall);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddAsync(HallDTO item)
    {
        var hall = new Hall
        {   
            Name = item.Name,
            Sections = _unitOfWork.Sections.GetListAsync(item.Sections!.ToList()).Result.ToList()
        };
        await _unitOfWork.Halls.CreateAsync(hall);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Halls.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}