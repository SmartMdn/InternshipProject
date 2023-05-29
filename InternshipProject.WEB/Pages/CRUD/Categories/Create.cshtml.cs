using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Categories
{
    internal class CreateModel : BasePage<Category, CategoryDTO>
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost([FromServices] ICRUDService<CategoryDTO> Service)
        {
            if (!ModelState.IsValid || Service.GetAll() == null || Category == null)
            {
                return Page();
            }
            ResultItem = MapperInput.Map<Category, CategoryDTO>(Category);
            Service.Post(ResultItem);

            return RedirectToPage("./Index");
        }
    }
}
