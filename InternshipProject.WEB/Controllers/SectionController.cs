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
    public SectionController(ICrudService<SectionDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override async Task<GetSectionViewModel> Get(int id)
    {
        var item = MapperOutput.Map<SectionDTO, GetSectionViewModel>(await Service.GetAsync(id));
        return item;
    }

    [HttpPut]
    public override async Task<IActionResult> Update(SectionViewModel item, int id)
    {
        ResultItem = MapperInput.Map<SectionViewModel, SectionDTO>(item);
        await Service.UpdateAsync(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override async Task<IActionResult> Add(SectionViewModel item)
    {
        ResultItem = MapperInput.Map<SectionViewModel, SectionDTO>(item);
        await Service.AddAsync(ResultItem);
        return new OkResult();
    }

    [HttpDelete]
    public override async Task<IActionResult> Delete(int id)
    {
        await Service.DeleteAsync(id);
        return new OkResult();
    }
}