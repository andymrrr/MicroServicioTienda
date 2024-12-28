using MediatR;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Comando.RegistrarLibroAutor
{
    public class RegistrarLibroAutorComando: IRequest<Unit>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

    }
}
