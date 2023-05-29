using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public class DeleteModel : BasePage<Stadium, StadiumDTO>
    {
        [BindProperty]
        public Stadium Stadium { get; set; } = default!;

        public IActionResult OnGet([FromServices] ICRUDService<StadiumDTO> Service, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }

            StadiumDTO stadium = Service.Get(id);

            if (stadium == null)
            {
                return NotFound();
            }
            else
            {
                Stadium = MapperOutput.Map<StadiumDTO, Stadium>(stadium);
            }
            return Page();
        }

        public IActionResult OnPost([FromServices] ICRUDService<StadiumDTO> Service, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }
            StadiumDTO stadium = Service.Get(id);

            if (stadium != null)
            {
                Stadium = MapperOutput.Map<StadiumDTO, Stadium>(stadium);
                Service.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
