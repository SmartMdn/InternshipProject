using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    public class CreateModel : BasePage<Hall, HallDTO>
    {
        public IActionResult OnGet([FromServices] ICRUDService<StadiumDTO> Service)
        {
            ViewData["StadiumId"] = new SelectList(Service.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Hall Hall { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost([FromServices] ICRUDService<HallDTO> Service)
        {
            if (!ModelState.IsValid || Service.GetAll() == null || Hall == null)
            {
                return Page();
            }
            ResultItem = MapperInput.Map<Hall, HallDTO>(Hall);
            ResultItem.StadiumId = Hall.StadiumId;
            Service.Post(ResultItem);

            return RedirectToPage("./Index");
        }
    }
}
