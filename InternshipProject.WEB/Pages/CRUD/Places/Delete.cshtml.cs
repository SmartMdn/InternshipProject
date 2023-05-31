using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Places
{
    public class DeleteModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public DeleteModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Place Place { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places.FirstOrDefaultAsync(m => m.Id == id);

            if (place == null)
            {
                return NotFound();
            }
            else 
            {
                Place = place;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }
            var place = await _context.Places.FindAsync(id);

            if (place != null)
            {
                Place = place;
                _context.Places.Remove(Place);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
