﻿using AutoMapper;
using InternshipProject.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Abstractions;

public abstract class CrudController<T, TK, L> : ControllerBase where TK : class
{
    protected readonly IMapper MapperInput = new MapperConfiguration(cfg => 
        cfg.CreateMap<T, TK>()).CreateMapper();
    protected readonly IMapper MapperOutput = new MapperConfiguration(cfg => 
        cfg.CreateMap<TK, L>()).CreateMapper();
    protected readonly ICRUDService<TK> Service;
    protected TK ResultItem;

    protected CrudController(ICRUDService<TK> service)
    {
        Service = service;
    }

    public abstract L Get(int id);
    public abstract IActionResult Update(T item, int id);
    public abstract IActionResult Add(T item);
    public abstract IActionResult Delete(int id);
}