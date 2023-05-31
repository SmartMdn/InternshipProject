using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    public class IndexModel : BasePage<Hall, HallDTO>
    {
        public IList<Hall> Hall { get; set; } = default!;
        public List<Stadium> Stadium { get; set; } = default!;

        public void OnGet([FromServices] ICRUDService<HallDTO> Service, [FromServices] ICRUDService<StadiumDTO> sService)
        {
            var MapperOutput1 = new MapperConfiguration(cfg => cfg.CreateMap<StadiumDTO, Stadium>()).CreateMapper();
            if (Service.GetAll() != null)
            {
                List<Hall> list = new();
                List<Stadium> list1 = new();
                foreach (HallDTO item in Service.GetAll())
                {
                    Hall result = MapperOutput.Map<HallDTO, Hall>(item);

                    Stadium stadium = MapperOutput1.Map<StadiumDTO, Stadium>(sService.Get(result.StadiumId));
                    list.Add(result);
                    list1.Add(stadium);
                }
                Hall = list;
                Stadium = list1;
            }
        }
    }
}
