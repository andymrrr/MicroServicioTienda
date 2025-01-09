using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ServicioTienda.Api.Gateway.Externo.Interfaz;
using ServicioTienda.Api.Gateway.Externo.Repositorio;
using ServicioTienda.Api.Gateway.Handler.Libros;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAutorExterno, RepositorioAutorExterno>();
builder.Services.AddHttpClient("ServicioAutor", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Servicios:autores"]);
});

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddDelegatingHandler<LibroHandler>(false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();
