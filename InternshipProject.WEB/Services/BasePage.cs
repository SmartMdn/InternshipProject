using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternshipProject.WEB.Services
{
    public abstract class BasePage<T,TK> : PageModel where T : class
    {
        protected readonly IMapper MapperInput = new MapperConfiguration(cfg =>
            cfg.CreateMap<T, TK>()).CreateMapper();
        protected readonly IMapper MapperOutput = new MapperConfiguration(cfg =>
            cfg.CreateMap<TK, T>()).CreateMapper();
        protected TK ResultItem;
    }
}
