using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class SectionCRUDService : ICrudService<SectionDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public SectionCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SectionDTO> GetAsync(int id)
    {
        var section = await _unitOfWork.Sections.GetAsync(id);
        if (section == null)
            throw new ValidationException("Билет не найден", "");
        var ids1 = (from st in section.Places select st.Id).ToArray();
        return new SectionDTO { Id = section.Id, Name = section.Name, Places = ids1};
    }

    public async Task<IEnumerable<SectionDTO>> GetAllAsync()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Section, SectionDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Section>, List<SectionDTO>>(await _unitOfWork.Sections.GetAllAsync());
    }

    public async Task UpdateAsync(SectionDTO item, int id)
    {
        var section = new Section
        {
            Id = id, 
            Name = item.Name,
            Places = _unitOfWork.Places.GetListAsync(item.Places!.ToList()).Result.ToList()
        };
        await _unitOfWork.Sections.UpdateAsync(section);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddAsync(SectionDTO item)
    {
        var section = new Section()
        {
            Name = item.Name,
            Places = _unitOfWork.Places.GetListAsync(item.Places!.ToList()).Result.ToList()
        };
        await _unitOfWork.Sections.CreateAsync(section);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Sections.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}