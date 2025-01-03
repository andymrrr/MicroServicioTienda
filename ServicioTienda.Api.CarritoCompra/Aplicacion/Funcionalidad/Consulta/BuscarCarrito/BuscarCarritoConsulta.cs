using MediatR;
using ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Vm;

namespace ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Consulta.BuscarCarrito
{
    public class BuscarCarritoConsulta : IRequest<CarritoVm>
    {
        public int CarritoSesionId { get; set; }

        public BuscarCarritoConsulta(int carritoSesionId)
        {
          
            if (carritoSesionId <= 0)
            {
                throw new ArgumentException("El ID del Carrito debe ser mayor que 0.", nameof(carritoSesionId));
            }

            CarritoSesionId = carritoSesionId;
        }
    }
}
