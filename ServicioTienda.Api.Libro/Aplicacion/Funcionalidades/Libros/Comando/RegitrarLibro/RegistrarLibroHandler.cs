using FluentValidation;
using MediatR;
using ServicioTienda.Api.Libro.Data.Context;
using ServicioTienda.Api.Libro.Modelo;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Comando.RegitrarLibro
{
    public class RegistrarLibroHandler : IRequestHandler<RegistrarLibroComando, Unit>
    {
        public readonly ContextLibreria _context;
        public RegistrarLibroHandler(ContextLibreria context)
        {
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

            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo Insertar el Libro");
        }
    }
}
