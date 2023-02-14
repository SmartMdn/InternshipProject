using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class SectionCRUDService : ICRUDService<SectionDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public SectionCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public SectionDTO Get(int id)
    {
        var section = _unitOfWork.Sections.GetAsync(id).Result;
        if (section == null)
            throw new ValidationException("Билет не найден", "");
        var ids1 = (from st in section.Places select st.Id).ToArray();
        return new SectionDTO { Id = section.Id, Name = section.Name, Places = ids1};
    }

    public IEnumerable<SectionDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Section, SectionDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Section>, List<SectionDTO>>(_unitOfWork.Sections.GetAllAsync().Result);
    }

    public void Put(SectionDTO item, int id)
    {
        var section = new Section
        {
            Id = id, 
            Name = item.Name,
            Places = _unitOfWork.Places.GetListAsync(item.Places!.ToList()).Result.ToList()
        };
        _unitOfWork.Sections.UpdateAsync(section);
        _unitOfWork.Save();
    }

    public void Post(SectionDTO item)
    {
        var section = new Section()
        {
            Name = item.Name,
            Places = _unitOfWork.Places.GetListAsync(item.Places!.ToList()).Result.ToList()
        };
        _unitOfWork.Sections.CreateAsync(section);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _unitOfWork.Sections.DeleteAsync(id);
        _unitOfWork.Save();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}