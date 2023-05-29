using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
internal class HallController : CrudController<Hall, HallDTO>
{
    public HallController(ICRUDService<HallDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override Hall Get(int id)
    {
        Hall item = MapperOutput.Map<HallDTO, Hall>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override IActionResult Update(Hall item, int id)
    {
        ResultItem = MapperInput.Map<Hall, HallDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(Hall item)
    {
        ResultItem = MapperInput.Map<Hall, HallDTO>(item);
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