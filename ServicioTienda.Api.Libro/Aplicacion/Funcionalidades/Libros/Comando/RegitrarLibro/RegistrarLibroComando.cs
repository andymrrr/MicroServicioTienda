using MediatR;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Comando.RegitrarLibro
{
    public class RegistrarLibroComando : IRequest<Unit>
    {
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
