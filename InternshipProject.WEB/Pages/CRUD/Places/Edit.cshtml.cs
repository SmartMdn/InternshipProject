using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Places
{
    public class EditModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public EditModel(InternshipProject.DAL.EF.CinemaContext context)
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

            var place =  await _context.Places.FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            Place = place;
           ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(Place.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlaceExists(int id)
        {
          return (_context.Places?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
