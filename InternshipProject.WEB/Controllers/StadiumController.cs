using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class StadiumController : CrudController<Stadium, StadiumDTO>
{
    public StadiumController(ICRUDService<StadiumDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override Stadium Get(int id)
    {
        var item = MapperOutput.Map<StadiumDTO, Stadium>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override string Put(Stadium item)
    {
        ResultItem = MapperInput.Map<Stadium, StadiumDTO>(item);
        Service.Put(ResultItem);
        return "Ивент успешно добавлен";
    }

    [HttpPost]
    public override string Post(Stadium item)
    {
        ResultItem = MapperInput.Map<Stadium, StadiumDTO>(item);
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