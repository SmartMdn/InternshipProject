using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController : CrudController<Place, PlaceDTO>
{
    public PlaceController(ICRUDService<PlaceDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override Place Get(int id)
    {
        var item = MapperOutput.Map<PlaceDTO, Place>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override string Update(Place item, int id)
    {
        ResultItem = MapperInput.Map<Place, PlaceDTO>(item);
        Service.Put(ResultItem, id);
        return "Место успешно изменено";
    }

    [HttpPost]
    public override string Add(Place item)
    {
        ResultItem = MapperInput.Map<Place, PlaceDTO>(item);
        Service.Post(ResultItem);
        return "Место успешно добавлен";
    }

    [HttpDelete]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Место успешно удалён";
    }
}