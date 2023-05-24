using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InternshipProject.WEB.Services;
using InternshipProject.WEB.Models;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;

namespace InternshipProject.WEB.Pages.CRUD.Tickets
{
    public class CreateModel : BasePage<Ticket, TicketDTO>
    {
        public IActionResult OnGet([FromServices] ICRUDService<EventDTO> eService, [FromServices] ICRUDService<PlaceDTO> pService)
        {
        ViewData["EventId"] = new SelectList(eService.GetAll(), "Id", "Id");
        ViewData["PlaceId"] = new SelectList(pService.GetAll(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync([FromServices] ICRUDService<TicketDTO> tService)
        {
          if (!ModelState.IsValid || tService.GetAll() == null || Ticket == null)
            {
                return Page();
            }
            ResultItem = MapperInput.Map<Ticket, TicketDTO>(Ticket);
            tService.Post(ResultItem);

            return RedirectToPage("./Index");
        }
    }
}
