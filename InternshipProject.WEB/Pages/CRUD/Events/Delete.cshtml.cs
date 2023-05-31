using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Events
{
    public class DeleteModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public DeleteModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var _event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (_event == null)
            {
                return NotFound();
            }
            else 
            {
                Event = _event;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var _event = await _context.Events.FindAsync(id);

            if (_event != null)
            {
                Event = _event;
                _context.Events.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
