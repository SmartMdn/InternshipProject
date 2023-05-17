using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
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
            return Page();
        }

        [BindProperty]
        public Stadium Stadium { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Stadiums == null || Stadium == null)
            {
                return Page();
            }

            _context.Stadiums.Add(Stadium);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
