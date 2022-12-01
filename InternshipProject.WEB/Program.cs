/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.Run();*/

using InternshipProject.BLL.Services;
using InternshipProject.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

var service = new BuyTicketService(new EFUnitOfWork(builder.Configuration.GetConnectionString("DefaultConnection")));
service.BuyTickets(new List<int>(){1,2});
Console.WriteLine("123");