using ApiCRUD.srcs.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using ApiCRUD.srcs.Application.Repository;
using ApiCRUD.srcs.Domain.Intrefaces.IUserRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
