using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    internal class CreateModel : BasePage<Stadium, StadiumDTO>
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stadium Stadium { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost([FromServices] ICRUDService<StadiumDTO> Service)
        {
            if (!ModelState.IsValid || Service.GetAll() == null || Stadium == null)
            {
                return Page();
            }
            ResultItem = MapperInput.Map<Stadium, StadiumDTO>(Stadium);
            Service.Post(ResultItem);

            return RedirectToPage("./Index");
        }
    }
}
