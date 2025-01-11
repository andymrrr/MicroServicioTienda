using FluentValidation;
using MediatR;
using ServicioTienda.Api.Libro.Data.Context;
using ServicioTienda.Api.Libro.Modelo;
using ServicioTienda.Api.RabbitMQ.Bus.Data.Interfaz;
using ServicioTienda.Api.RabbitMQ.Bus.EventoCola;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Comando.RegitrarLibro
{
    public class RegistrarLibroHandler : IRequestHandler<RegistrarLibroComando, Unit>
    {
        public readonly ContextLibreria _context;
        private readonly IRabbitEventBus _rabbitEventBus;
        public RegistrarLibroHandler(ContextLibreria context, IRabbitEventBus rabbitEventBus)
        {
            _rabbitEventBus = rabbitEventBus;
            _context = context;
        }
        public async Task<Unit> Handle(RegistrarLibroComando request, CancellationToken cancellationToken)
        {
            var libro = new Modelo.Libros
            {
                Titulo = request.Titulo,
                FechaPublicacion = request.FechaPublicacion,
                Autor = request.AutorLibro
            };

            _context.Libros.Add(libro);
            var resultado = await _context.SaveChangesAsync();

            _rabbitEventBus.Publish(new ColaEventosEmail("andymrrrr@gmail.com",request.Titulo, "Esto es una prueba"));
            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo Insertar el Libro");
        }
    }
}
