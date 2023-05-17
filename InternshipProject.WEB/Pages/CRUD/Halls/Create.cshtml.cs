using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternshipProject.WEB.Pages.CRUD.Halls
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
            ViewData["StadiumId"] = new SelectList(_context.Stadiums, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Hall Hall { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Halls == null || Hall == null)
            {
                return Page();
            }

            _context.Halls.Add(Hall);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
