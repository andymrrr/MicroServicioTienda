using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.CarritoCompra.Data.Context;
using ServicioTienda.Api.CarritoCompra.Data.InterfazRemota.Libro;
using ServicioTienda.Api.CarritoCompra.Data.RepositorioRemoto.Libros;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<InterfazLibro, RepositorioLibro>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextCarrito>(op =>
{
    op.UseMySQL(builder.Configuration.GetConnectionString("CarritoCompra"));
});
builder.Services.AddMediatR(opcion => opcion.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpClient("libros", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Servicios:libros"]);
});
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
