using MediatR;
using ServicioTienda.Api.CarritoCompra.Data.Context;
using ServicioTienda.Api.CarritoCompra.Modelo;

namespace ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.CarritoSesiones
{
    public class RegistrarCarritoSesionHandler : IRequestHandler<RegistrarCarritoSesionComando, Unit>
    {
        public readonly ContextCarrito _context;
        public RegistrarCarritoSesionHandler(ContextCarrito context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(RegistrarCarritoSesionComando request, CancellationToken cancellationToken)
        {
            var carritosesion = new CarritoSesion
            {
                FechaCreacion = request.FechaCreacion,
            };

            _context.CarritoSesions.Add(carritosesion);
            var value = await _context.SaveChangesAsync();
            if (value ==0)
            {
                throw new Exception("Error al registrar el carrito");
            }
            int idSesion = carritosesion.CarritoSesionId;
            foreach (var item in request.ListaLibro)
            {
                var detalleSedion = new CarritoSesionDetalle
                {
                    FechaCreacion = DateTime.Now,
                    CarritoSesionId = idSesion,
                    libroSeleccionado = item
                };
                _context.CarritoSesionDetalles.Add(detalleSedion);
            }

            value = await _context.SaveChangesAsync();
            if (value > 0)
            {
                return Unit.Value;
            }

          
                throw new Exception("Error al registrar el carrito");
           

        }
    }
}
