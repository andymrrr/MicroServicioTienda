using MediatR;

namespace ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.CarritoSesiones
{
    public class RegistrarCarritoSesionComando : IRequest<Unit>
    {
        public DateTime? FechaCreacion { get; set; }
        public List<string> ListaLibro { get; set; }

    }
}
