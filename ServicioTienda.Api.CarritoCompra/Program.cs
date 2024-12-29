using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.CarritoCompra.Data.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextCarrito>(op =>
{
    op.UseMySQL(builder.Configuration.GetConnectionString("CarritoCompra"));
});
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
