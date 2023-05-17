using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.WEB.Pages.CRUD.Sections
{
    public class IndexModel : PageModel
    {
        private readonly CinemaContext _context;

        public IndexModel(CinemaContext context)
        {
            _context = context;
        }

        public IList<Section> Section { get; set; } = default!;

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
