using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ICRUDService<EventDTO> _eventService;
    private readonly ILogger<EventController> _logger;

    public EventController(ICRUDService<EventDTO> eventService, ILogger<EventController> logger)
    {
        _eventService = eventService;
        _logger = logger;
    }
    
    [HttpGet(Name = "GetEvent")]
    public Event Get(int id)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var item = mapper.Map<EventDTO, Event>(_eventService.Get(id));
        return item;
    }

    [HttpPost]
    public void Post(Event item)
    {
        
    }
}