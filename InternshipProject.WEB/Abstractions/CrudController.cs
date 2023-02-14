using AutoMapper;
using InternshipProject.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Abstractions;

public abstract class CrudController<T, TK, TL> : ControllerBase where TK : class
{
    protected readonly IMapper MapperInput = new MapperConfiguration(cfg => 
        cfg.CreateMap<T, TK>()).CreateMapper();
    protected readonly IMapper MapperOutput = new MapperConfiguration(cfg => 
        cfg.CreateMap<TK, TL>()).CreateMapper();
    protected readonly ICRUDService<TK> Service;
    protected TK ResultItem;

    protected CrudController(ICRUDService<TK> service)
    {
        Service = service;
    }

    public abstract TL Get(int id);
    public abstract IActionResult Update(T item, int id);
    public abstract IActionResult Add(T item);
    public abstract IActionResult Delete(int id);
}