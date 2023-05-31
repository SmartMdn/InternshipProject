using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    public class EditModel : BasePage<Hall, HallDTO>
    {
        [BindProperty]
        public Hall Hall { get; set; } = default!;

        public IActionResult OnGet([FromServices] ICRUDService<HallDTO> hService, [FromServices] ICRUDService<StadiumDTO> sService, int? id)
        {
            if (id == null || hService.GetAll() == null)
            {
                return NotFound();
            }

            HallDTO hall = hService.Get(id);
            if (hall == null)
            {
                return NotFound();
            }
            Hall = MapperOutput.Map<HallDTO, Hall>(hall);
            ViewData["StadiumId"] = new SelectList(sService.GetAll(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost([FromServices] ICRUDService<HallDTO> Service)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ResultItem = MapperInput.Map<Hall, HallDTO>(Hall);
            Service.Put(ResultItem, Hall.Id);

            return RedirectToPage("./Index");
        }
    }
}
