using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Libro.Data.Context;
using System.Globalization;
using System.Reflection;
using AutoMapper;
using ServicioTienda.Api.Libro.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextLibreria>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Libro"));
});
//Registro Mapeo
var cofiguracionMapeo = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapeoPerfil());
});
IMapper mapeo = cofiguracionMapeo.CreateMapper();
builder.Services.AddSingleton(mapeo);
builder.Services.AddMediatR(opcion => opcion.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
