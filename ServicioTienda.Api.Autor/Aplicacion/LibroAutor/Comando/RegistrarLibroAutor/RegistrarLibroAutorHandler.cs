using MediatR;
using ServicioTienda.Api.Autor.Data.Context;
using ServicioTienda.Api.Autor.Modelo;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Comando.RegistrarLibroAutor
{
    public class RegistrarLibroAutorHandler : IRequestHandler<RegistrarLibroAutorComando, Unit>
    {
        public readonly ContextAutor _context;
        public RegistrarLibroAutorHandler(ContextAutor context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RegistrarLibroAutorComando request, CancellationToken cancellationToken)
        {
            var autorLibro = new AutorLibro
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                FechaNacimiento = request.FechaNacimiento,
                AutorlibroGuid = Convert.ToString(Guid.NewGuid())
                
            };

            _context.AutorLibros.Add(autorLibro);
            var resultado = await _context.SaveChangesAsync();

            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo Insertar el autor");

        }
    }
}
