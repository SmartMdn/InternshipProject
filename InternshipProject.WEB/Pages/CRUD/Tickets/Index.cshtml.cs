using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public IndexModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tickets != null)
            {
                Ticket = await _context.Tickets
                .Include(t => t.Event)
                .Include(t => t.Place).ToListAsync();
            }
        }
    }
}
