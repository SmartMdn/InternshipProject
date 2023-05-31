using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Services;
using InternshipProject.WEB.Models;

namespace InternshipProject.WEB.Pages.CRUD.Events
{
    public class CreateModel : BasePage<Event,EventDTO>
    {
        public IActionResult OnGet([FromServices] ICRUDService<HallDTO> hService, [FromServices] ICRUDService<CategoryDTO> cService)
        {
            ViewData["CategoryId"] = new SelectList(cService.GetAll(), "Id", "Id");
            ViewData["HallId"] = new SelectList(hService.GetAll(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost([FromServices] ICRUDService<EventDTO> service)
        {
            if (!ModelState.IsValid || service.GetAll() == null || Event == null)
            {
                return Page();
            }

            ResultItem = MapperInput.Map<Event, EventDTO>(Event);
            service.Post(ResultItem);

            return RedirectToPage("./Index");
        }
    }
}
