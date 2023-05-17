using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternshipProject.WEB.Pages.CRUD.Places
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
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Place Place { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Places == null || Place == null)
            {
                return Page();
            }

            _context.Places.Add(Place);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
