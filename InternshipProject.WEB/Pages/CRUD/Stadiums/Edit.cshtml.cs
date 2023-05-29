using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    internal class EditModel : BasePage<Stadium, StadiumDTO>
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
            Stadium = MapperOutput.Map<StadiumDTO, Stadium>(stadium);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost([FromServices] ICRUDService<StadiumDTO> Service)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ResultItem = MapperInput.Map<Stadium, StadiumDTO>(Stadium);
            Service.Put(ResultItem, Stadium.Id);

            return RedirectToPage("./Index");
        }
    }
}
