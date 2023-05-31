using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.WEB.Pages.CRUD.Sections
{
    public class DetailsModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public DetailsModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

      public Section Section { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sections == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FirstOrDefaultAsync(m => m.Id == id);
            if (section == null)
            {
                return NotFound();
            }
            else 
            {
                Section = section;
            }
            return Page();
        }
    }
}
