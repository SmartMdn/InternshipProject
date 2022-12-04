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

    [HttpGet]
    public override Hall Get(int id)
    {
        var item = MapperOutput.Map<HallDTO, Hall>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override string Put(Hall item, int id)
    {
        ResultItem = MapperInput.Map<Hall, HallDTO>(item);
        Service.Put(ResultItem, id);
        return "Ивент успешно добавлен";
    }

    [HttpPost]
    public override string Post(Hall item)
    {
        ResultItem = MapperInput.Map<Hall, HallDTO>(item);
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