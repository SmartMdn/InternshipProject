using InternshipProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternshipProject.WEB.Pages.CRUD.Events
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
            ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Events == null || Event == null)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
