using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.BLL.Services;
using InternshipProject.DAL.Interfaces;
using InternshipProject.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InternshipProject.DAL.EF;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddTransient<IUnitOfWork>(provider =>
    new EFUnitOfWork(builder.Configuration.GetConnectionString("DataDB")));

builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDB")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthContext>();
services.AddTransient<ICRUDService<EventDTO>, EventCRUDService>();
services.AddTransient<ICRUDService<HallDTO>, HallCRUDService>();
services.AddTransient<ICRUDService<StadiumDTO>, StadiumCRUDService>();
services.AddTransient<ICRUDService<SectionDTO>, SectionCRUDService>();
services.AddTransient<ICRUDService<PlaceDTO>, PlaceCRUDService>();
services.AddTransient<ICRUDService<TicketDTO>, TicketCRUDService>();
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddRazorPages();
services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.MapBlazorHub();
app.MapFallbackToPage("/Shared/_Layout");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();