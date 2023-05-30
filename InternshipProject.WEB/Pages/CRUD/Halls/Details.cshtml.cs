using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    public class DetailsModel : BasePage<Hall, HallDTO>
    {
        public Hall Hall { get; set; } = default!;
        public Stadium Stadium { get; set; } = default!;

        public IActionResult OnGet([FromServices] ICRUDService<HallDTO> Service, [FromServices] ICRUDService<StadiumDTO> sService, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }

            HallDTO item = Service.Get(id);
            StadiumDTO stadium = sService.Get(item.StadiumId);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Hall = MapperOutput.Map<HallDTO, Hall>(item);
                Stadium = MapperOutput.Map<StadiumDTO, Stadium>(stadium);
            }
            return Page();
        }
    }
}
