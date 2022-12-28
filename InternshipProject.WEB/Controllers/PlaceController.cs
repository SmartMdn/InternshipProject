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
    public override IActionResult Update(Place item, int id)
    {
        ResultItem = MapperInput.Map<Place, PlaceDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(Place item)
    {
        ResultItem = MapperInput.Map<Place, PlaceDTO>(item);
        Service.Post(ResultItem);
        return new OkResult();
    }

    [HttpDelete]
    public override IActionResult Delete(int id)
    {
        Service.Delete(id);
        return new OkResult();
    }
}