using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternshipProject.WEB.Models;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Services;
using InternshipProject.BLL.DTO;

namespace InternshipProject.WEB.Pages.CRUD.Stadiums
{
    public class IndexModel : BasePage<Stadium, StadiumDTO>
    {
        public List<Stadium> Stadium { get;set; } = default!;

        public void OnGet([FromServices] ICRUDService<StadiumDTO> sService)
        {
            if (sService.GetAll() != null)
            {
                foreach (var item in sService.GetAll())
                {
                    var result = MapperOutput.Map<StadiumDTO, Stadium>(item);
                    Stadium.Add(result);
                }
            }
        }
    }
}
