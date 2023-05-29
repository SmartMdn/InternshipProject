using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    internal class DetailsModel : BasePage<Stadium, StadiumDTO>
    {
        public Stadium Stadium { get; set; } = default!;

        public IActionResult OnGet([FromServices] ICRUDService<StadiumDTO> Service, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }

            StadiumDTO item = Service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Stadium = MapperOutput.Map<StadiumDTO, Stadium>(item);
            }
            return Page();
        }
    }
}
