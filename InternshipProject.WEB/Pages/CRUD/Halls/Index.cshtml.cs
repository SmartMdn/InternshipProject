using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    internal class IndexModel : BasePage<Hall, HallDTO>
    {
        public IList<Hall> Hall { get; set; } = default!;

        public void OnGet([FromServices] ICRUDService<HallDTO> Service)
        {
            if (Service.GetAll() != null)
            {
                List<Hall> list = new();
                foreach (HallDTO item in Service.GetAll())
                {
                    Hall result = MapperOutput.Map<HallDTO, Hall>(item);
                    list.Add(result);
                }
                Hall = list;
            }
        }
    }
}
