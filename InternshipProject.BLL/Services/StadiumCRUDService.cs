using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class StadiumCRUDService : ICrudService<StadiumDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public StadiumCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<StadiumDTO> GetAsync(int id)
    {
        var stadium = await _unitOfWork.Stadiums.GetAsync(id);
        if (stadium == null)
            throw new ValidationException("Билет не найден", "");
        var ids = (from st in stadium.Halls select st.Id).ToArray();
        return new StadiumDTO { Id =stadium.Id , Address = stadium.Address, Name = stadium.Name, Halls = ids};
    }

    public async Task<IEnumerable<StadiumDTO>> GetAllAsync()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stadium, StadiumDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Stadium>, List<StadiumDTO>>(await _unitOfWork.Stadiums.GetAllAsync());
    }

    public async Task UpdateAsync(StadiumDTO item, int id)
    {
        var stadium = new Stadium
        {
            Id = id,
            Address = item.Address, 
            Halls = _unitOfWork.Halls.GetListAsync(item.Halls!.ToList()).Result.ToList(),
            Name = item.Name
        };
        await _unitOfWork.Stadiums.UpdateAsync(stadium);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddAsync(StadiumDTO item)
    {
        if (_unitOfWork.Stadiums.GetAllAsync().Result.Any(o => o.Name == item.Name || o.Address == item.Name))
        {
            return;
        }
        var stadium = new Stadium
        {
            Address = item.Address,
            Halls = _unitOfWork.Halls.GetListAsync(item.Halls!.ToList()).Result.ToList(), 
            Name = item.Name
        };
        await _unitOfWork.Stadiums.CreateAsync(stadium);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Stadiums.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}