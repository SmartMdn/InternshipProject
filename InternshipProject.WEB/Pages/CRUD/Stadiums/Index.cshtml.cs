using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public class IndexModel : PageModel
    {
        private readonly InternshipProject.DAL.EF.CinemaContext _context;

        public IndexModel(InternshipProject.DAL.EF.CinemaContext context)
        {
            _context = context;
        }

        public IList<Stadium> Stadium { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stadiums != null)
            {
                Stadium = await _context.Stadiums.ToListAsync();
            }
        }
    }
}
