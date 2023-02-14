using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class HallCRUDService : ICRUDService<HallDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public HallCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public HallDTO Get(int id)
    {
        var hall = _unitOfWork.Halls.Get(id);
        if (hall == null)
            throw new ValidationException("Билет не найден", "");
        return new HallDTO { Id = hall.Id, Name = hall.Name};
    }

    public IEnumerable<HallDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hall, HallDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Hall>, List<HallDTO>>(_unitOfWork.Halls.GetAll());
    }

    public void Put(HallDTO item, int id)
    {
        var hall = new Hall
        {
            Id = id,
            Name = item.Name,
            Sections = _unitOfWork.Sections.GetList(item.Sections!.ToList()).ToList()
        };
        _unitOfWork.Halls.Update(hall);
        _unitOfWork.Save();
    }

    public void Post(HallDTO item)
    {
        var hall = new Hall
        {   
            Name = item.Name,
            Sections = _unitOfWork.Sections.GetList(item.Sections!.ToList()).ToList()
        };
        _unitOfWork.Halls.Create(hall);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _unitOfWork.Halls.Delete(id);
        _unitOfWork.Save();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}