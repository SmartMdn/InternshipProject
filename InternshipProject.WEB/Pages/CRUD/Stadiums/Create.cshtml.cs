using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public class CreateModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stadium Stadium { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync([FromServices] ICRUDService<StadiumDTO> sService)
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
