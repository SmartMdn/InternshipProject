﻿using AutoMapper;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Interfaces;

public abstract class CrudController<T, TK> : ControllerBase where TK : class
{
    protected readonly IMapper MapperInput = new MapperConfiguration(cfg => 
        cfg.CreateMap<T, TK>()).CreateMapper();
    protected readonly IMapper MapperOutput = new MapperConfiguration(cfg => 
        cfg.CreateMap<TK, T>()).CreateMapper();
    protected readonly ICRUDService<TK> Service;
    protected TK ResultItem;

    protected CrudController(ICRUDService<TK> service)
    {
        Service = service;
    }

    public abstract T Get(int id);
    public abstract string Put(T item, int id);
    public abstract string Post(T item);
    public abstract string Delete(int id);
}