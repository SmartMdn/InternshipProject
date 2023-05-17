using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.WEB.Pages.CRUD.Places
{
    public class IndexModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public IndexModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        public IList<Place> Place { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Places != null)
            {
                Place = await _context.Places
                .Include(p => p.Section).ToListAsync();
            }
        }
    }
}
