using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternshipProject.BLL.DTO;
using InternshipProject.WEB.Services;
using InternshipProject.WEB.Models;
using InternshipProject.BLL.Interfaces;

namespace InternshipProject.WEB.Pages.CRUD.Events
{
    public class EditModel : BasePage<Event, EventDTO>
    {
        [BindProperty]
        public Event Event { get; set; } = default!;

        public IActionResult OnGet([FromServices] ICRUDService<EventDTO> eService, [FromServices] ICRUDService<HallDTO> hService, [FromServices] ICRUDService<CategoryDTO> cService, int? id)
        {
            if (id == null || hService.GetAll() == null)
            {
                return NotFound();
            }

            EventDTO _event = eService.Get(id);
            if (_event == null)
            {
                return NotFound();
            }
            Event = MapperOutput.Map<EventDTO, Event>(_event);
            ViewData["CategoryId"] = new SelectList(cService.GetAll(), "Id", "Id");
            ViewData["HallId"] = new SelectList(hService.GetAll(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost([FromServices] ICRUDService<EventDTO> eService)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            ResultItem = MapperInput.Map<Event, EventDTO>(Event);
            eService.Put(ResultItem, Event.Id);
            return RedirectToPage("./Index");
        }
    }
}
