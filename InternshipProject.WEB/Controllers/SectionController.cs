using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionController : CrudController<SectionViewModel, SectionDTO, GetSectionViewModel>
{
    public SectionController(ICRUDService<SectionDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override GetSectionViewModel Get(int id)
    {
        var item = MapperOutput.Map<SectionDTO, GetSectionViewModel>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override IActionResult Update(SectionViewModel item, int id)
    {
        ResultItem = MapperInput.Map<SectionViewModel, SectionDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(SectionViewModel item)
    {
        ResultItem = MapperInput.Map<SectionViewModel, SectionDTO>(item);
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