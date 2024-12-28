using MediatR;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarLibroGuid
{
    public class BuscarLibroGuidConsulta : IRequest<LibroVm>
    {
        public Guid? LibroGuid { get; set; }


        public BuscarLibroGuidConsulta(Guid? libroGuid)
        {

            if (libroGuid is null)
            {
                throw new ArgumentException("El ID del libro no puede estar vacio", nameof(libroGuid));
            }

            LibroGuid = libroGuid;
        }
    }
}
