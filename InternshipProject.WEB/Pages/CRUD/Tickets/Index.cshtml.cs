using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.BLL.DTO;
using InternshipProject.WEB.Services;
using InternshipProject.WEB.Models;
using InternshipProject.BLL.Interfaces;

namespace InternshipProject.WEB.Pages.CRUD.Tickets
{
    public class IndexModel : BasePage<Ticket, TicketDTO>
    {
        public List<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync([FromServices] ICRUDService<TicketDTO> tService)
        {
            if (tService.GetAll() != null)
            {
                foreach (var item in tService.GetAll())
                {
                    var result = MapperOutput.Map<TicketDTO, Ticket>(item);
                    Ticket.Add(result);
                }
            }
        }
    }
}
