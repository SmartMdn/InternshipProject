using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Services;
using InternshipProject.BLL.DTO;
using InternshipProject.WEB.Models;

namespace InternshipProject.WEB.Pages.CRUD.Events
{
    public class IndexModel : BasePage<Event,EventDTO>
    {
        public List<Event> Event { get;set; } = default!;
        public List<Hall> EventHall { get;set; } = default!;
        public List<Category> Category { get; set; } = default!;

        public async Task OnGetAsync([FromServices] ICRUDService<EventDTO> service)
        {
            if (service.GetAll() != null)
            {
                List<Event> list = new();
                foreach (EventDTO item in service.GetAll())
                {
                    Event result = MapperOutput.Map<EventDTO, Event>(item);
                    list.Add(result);
                }
                Event = list;
            }
        }
    }
}
