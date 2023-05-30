using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public class IndexModel : BasePage<Stadium, StadiumDTO>
    {
        public List<Stadium> Stadium { get; set; } = default!;

        public void OnGet([FromServices] ICRUDService<StadiumDTO> Service)
        {
            if (Service.GetAll() != null)
            {
                List<Stadium> list = new();
                foreach (StadiumDTO item in Service.GetAll())
                {
                    Stadium result = MapperOutput.Map<StadiumDTO, Stadium>(item);
                    list.Add(result);
                }
                Stadium = list;
            }

        }
    }
}
