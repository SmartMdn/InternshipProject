using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class HallController : CrudController<Hall, HallDTO>
{
    public HallController(ICRUDService<HallDTO> service) : base(service)
    {
    }

    [HttpGet("Get")]
    public override Hall Get(int id)
    {
        var item = MapperOutput.Map<HallDTO, Hall>(Service.Get(id));
        return item;
    }

    [HttpPut("Update")]
    public override string Put(Hall item, int id)
    {
        ResultItem = MapperInput.Map<Hall, HallDTO>(item);
        Service.Put(ResultItem, id);
        return "Зал успешно изменён";
    }

    [HttpPost("Add")]
    public override string Post(Hall item)
    {
        ResultItem = MapperInput.Map<Hall, HallDTO>(item);
        Service.Post(ResultItem);
        return "Зал успешно добавлен";
    }

    [HttpDelete("Delete")]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Зал успешно удалён";
    }
}