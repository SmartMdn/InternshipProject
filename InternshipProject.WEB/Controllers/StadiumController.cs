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
    public override IActionResult Update(Stadium item, int id)
    {
        ResultItem = MapperInput.Map<Stadium, StadiumDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(Stadium item)
    {
        ResultItem = MapperInput.Map<Stadium, StadiumDTO>(item);
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