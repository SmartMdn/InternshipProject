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

    [HttpGet("Get")]
    public override Stadium Get(int id)
    {
        var item = MapperOutput.Map<StadiumDTO, Stadium>(Service.Get(id));
        return item;
    }

    [HttpPut("Update")]
    public override string Put(Stadium item, int id)
    {
        ResultItem = MapperInput.Map<Stadium, StadiumDTO>(item);
        Service.Put(ResultItem, id);
        return "Стадион успешно изменён";
    }

    [HttpPost("Add")]
    public override string Post(Stadium item)
    {
        ResultItem = MapperInput.Map<Stadium, StadiumDTO>(item);
        Service.Post(ResultItem);
        return "Стадион успешно добавлен";
    }

    [HttpDelete("Delete")]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Стадион успешно удалён";
    }
}