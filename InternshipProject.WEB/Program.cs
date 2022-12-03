using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.BLL.Services;
using InternshipProject.DAL.Interfaces;
using InternshipProject.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUnitOfWork>(provider =>
    new EFUnitOfWork(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ICRUDService<EventDTO>, EventCRUDService>();
builder.Services.AddTransient<ICRUDService<HallDTO>, HallCRUDService>();
builder.Services.AddTransient<ICRUDService<StadiumDTO>, StadiumCRUDService>();
builder.Services.AddTransient<ICRUDService<SectionDTO>, SectionCRUDService>();
builder.Services.AddTransient<ICRUDService<PlaceDTO>, PlaceCRUDService>();
builder.Services.AddTransient<ICRUDService<TicketDTO>, TicketCRUDService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();