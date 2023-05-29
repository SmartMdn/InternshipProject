using InternshipProject.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public interface IDeleteModel<T, TK>
        where T : class
        where TK : class
    {
        T Item { get; set; }

        IActionResult OnGet([FromServices] ICRUDService<TK> Service, int? id);
        IActionResult OnPost([FromServices] ICRUDService<TK> Service, int? id);
    }
}