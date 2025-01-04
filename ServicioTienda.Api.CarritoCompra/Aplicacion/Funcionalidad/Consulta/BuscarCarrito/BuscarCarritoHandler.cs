using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Vm;
using ServicioTienda.Api.CarritoCompra.Data.Context;
using ServicioTienda.Api.CarritoCompra.Data.InterfazRemota.Libro;

namespace ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Consulta.BuscarCarrito
{
    public class BuscarCarritoHandler : IRequestHandler<BuscarCarritoConsulta, CarritoVm>
    {

        public readonly ContextCarrito _context;
        private readonly InterfazLibro _interfazLibro; 
        public BuscarCarritoHandler(ContextCarrito context, InterfazLibro interfazLibro)
        {
            _context = context;
            _interfazLibro = interfazLibro;
        }
        public async Task<CarritoVm> Handle(BuscarCarritoConsulta request, CancellationToken cancellationToken)
        {
            var carritoSesion = await _context.CarritoSesions.Where(d => d.CarritoSesionId == request.CarritoSesionId).FirstOrDefaultAsync();

            var carritoSesionDetalle = await _context.CarritoSesionDetalles.Where(d => d.CarritoSesionId == request.CarritoSesionId).ToListAsync();
            var  listaCarritoDetalles = new List<CarritoDetalleVm>();
            foreach (var item in carritoSesionDetalle)
            {
               var respuesta = await _interfazLibro.BuscarLibro(new Guid(item.libroSeleccionado));
                if (respuesta.resultado)
                {
                    var objLibro = respuesta.libro;

                    var carritoDetalle = new CarritoDetalleVm
                    {
                        LibroId = objLibro.Id,
                        TituloLibro= objLibro.Titulo,
                        FechaPublicacion = objLibro.FechaPublicacion,
                    };

                    listaCarritoDetalles.Add(carritoDetalle);
                }


            }

            var carritoVm = new CarritoVm
            {
                CarritoSesionId = request.CarritoSesionId,
                FechaCreacion = carritoSesion.FechaCreacion,
                CarritoDetalles = listaCarritoDetalles
            };
           
            return carritoVm;
        }
    }
}
