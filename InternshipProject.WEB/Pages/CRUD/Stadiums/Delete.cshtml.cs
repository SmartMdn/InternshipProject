using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public class DeleteModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public DeleteModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Stadium Stadium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums.FirstOrDefaultAsync(m => m.Id == id);

            if (stadium == null)
            {
                return NotFound();
            }
            else 
            {
                Stadium = stadium;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }
            var stadium = await _context.Stadiums.FindAsync(id);

            if (stadium != null)
            {
                Stadium = stadium;
                _context.Stadiums.Remove(Stadium);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
