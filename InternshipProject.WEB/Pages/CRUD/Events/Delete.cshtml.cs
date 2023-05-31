using Microsoft.AspNetCore.Mvc;
using InternshipProject.BLL.Interfaces;
using InternshipProject.BLL.DTO;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;

namespace InternshipProject.WEB.Pages.CRUD.Events
{
    public class DeleteModel : BasePage<Event,EventDTO>
    {
        [BindProperty]
        public Event Event { get; set; } = default!;
        public Hall EventHall { get; set; } = default!;
        public Category Category { get; set; } = default!;

        public IActionResult OnGet([FromServices] ICRUDService<EventDTO> eService, [FromServices] ICRUDService<HallDTO> hService, [FromServices] ICRUDService<CategoryDTO> cService, int? id)
        {
            if (id == null || eService.GetAll() == null)
            {
                return NotFound();
            }

            EventDTO _event = eService.Get(id);
            HallDTO hall = hService.Get(_event.HallId);
            CategoryDTO category = cService.Get(_event.CagegoryId);

            if (_event == null)
            {
                return NotFound();
            }
            else
            {
                Event = MapperOutput.Map<EventDTO, Event>(_event);
                Category = MapperOutput.Map<CategoryDTO, Category>(category);
                EventHall = MapperOutput.Map<HallDTO, Hall>(hall);
            }
            return Page();
        }

        public IActionResult OnPost([FromServices] ICRUDService<EventDTO> eService, int? id)
        {
            if (id == null || eService.GetAll() == null)
            {
                return NotFound();
            }
            EventDTO _event = eService.Get(id);

            if (_event != null)
            {
                Event = MapperOutput.Map<EventDTO, Event>(_event);
                eService.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
