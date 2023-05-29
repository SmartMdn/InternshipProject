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

        public IActionResult OnGet([FromServices] ICRUDService<HallDTO> Service, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }

            HallDTO item = Service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Hall = MapperOutput.Map<HallDTO, Hall>(item);
            }
            return Page();
        }
    }
}
