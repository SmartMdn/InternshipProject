using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    public class IndexModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public IndexModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        public IList<Hall> Hall { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Halls != null)
            {
                Hall = await _context.Halls
                .Include(h => h.Stadium).ToListAsync();
            }
        }
    }
}
