using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController : CrudController<PlaceViewModel, PlaceDTO, GetPlaceViewModel>
{
    public PlaceController(ICrudService<PlaceDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override async Task<GetPlaceViewModel> Get(int id)
    {
        var item = MapperOutput.Map<PlaceDTO, GetPlaceViewModel>(await Service.GetAsync(id));
        return item;
    }

    [HttpPut]
    public override async Task<IActionResult> Update(PlaceViewModel item, int id)
    {
        ResultItem = MapperInput.Map<PlaceViewModel, PlaceDTO>(item);
        await Service.UpdateAsync(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override async Task<IActionResult> Add(PlaceViewModel item)
    {
        ResultItem = MapperInput.Map<PlaceViewModel, PlaceDTO>(item);
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