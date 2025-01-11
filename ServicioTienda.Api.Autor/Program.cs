using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Autor.Data.Context;
using ServicioTienda.Api.Autor.ManejadorRabbit;
using ServicioTienda.Api.Autor.Mapper;
using ServicioTienda.Api.RabbitMQ.Bus;
using ServicioTienda.Api.RabbitMQ.Bus.Data.Interfaz;
using ServicioTienda.Api.RabbitMQ.Bus.EventoCola;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServicioRabbitMQ(builder.Configuration);
builder.Services.AddTransient<IEventoManejador<ColaEventosEmail>, ManejadorEventoEmail>();
builder.Services.AddTransient<ManejadorEventoEmail>();
builder.Services.AddDbContext<ContextAutor>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("Autor"));
});
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(opcion => opcion.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
//Registro Mapeo
var cofiguracionMapeo = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapeoPerfil());
});
IMapper mapeo = cofiguracionMapeo.CreateMapper();
builder.Services.AddSingleton(mapeo);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

var eventBus = app.Services.GetRequiredService<IRabbitEventBus>();
eventBus.Suscribe<ColaEventosEmail, ManejadorEventoEmail>();


app.Run();
