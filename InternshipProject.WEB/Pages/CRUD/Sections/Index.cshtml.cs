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
    public class IndexModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public IndexModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        public IList<Section> Section { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sections != null)
            {
                Section = await _context.Sections
                .Include(s => s.Hall).ToListAsync();
            }
        }
    }
}
