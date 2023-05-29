﻿using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Halls
{
    public class DeleteModel : BasePage<Hall, HallDTO>
    {
        [BindProperty]
        public Hall Hall { get; set; } = default!;
        public IActionResult OnGet([FromServices] ICRUDService<HallDTO> Service, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }

            HallDTO hall = Service.Get(id);

            if (hall == null)
            {
                return NotFound();
            }
            else
            {
                Hall = MapperOutput.Map<HallDTO, Hall>(hall);
            }
            return Page();
        }

        public IActionResult OnPost([FromServices] ICRUDService<HallDTO> Service, int? id)
        {
            if (id == null || Service.GetAll() == null)
            {
                return NotFound();
            }
            HallDTO hall = Service.Get(id);

            if (hall != null)
            {
                Hall = MapperOutput.Map<HallDTO, Hall>(hall);
                Service.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
