using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionController : CrudController<Section, SectionDTO>
{
    public SectionController(ICRUDService<SectionDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override Section Get(int id)
    {
        var item = MapperOutput.Map<SectionDTO, Section>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override string Put(Section item)
    {
        ResultItem = MapperInput.Map<Section, SectionDTO>(item);
        Service.Put(ResultItem);
        return "Ивент успешно добавлен";
    }

    [HttpPost]
    public override string Post(Section item)
    {
        ResultItem = MapperInput.Map<Section, SectionDTO>(item);
        Service.Post(ResultItem);
        return "Ивент успешно изменён";
    }

    [HttpDelete]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Ивент успешно удалён";
    }
}