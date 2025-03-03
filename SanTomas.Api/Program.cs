using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SanTomas.Application.MainCategories.Services;
using SanTomas.Application.MainCategories.Services.Interfaces;
using SanTomas.Infra.Contexts;
using SanTomas.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
//builder.Services.AddScoped(IMainCategoriesApplication, MainCategoriesApplication);

builder.Services.AddAutoMapper(typeof(Profile));

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SanTomasDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

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