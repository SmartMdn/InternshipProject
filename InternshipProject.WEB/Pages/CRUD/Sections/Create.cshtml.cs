using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Sections
{
    public class CreateModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public CreateModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Section Section { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sections == null || Section == null)
            {
                return Page();
            }

            _context.Sections.Add(Section);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
