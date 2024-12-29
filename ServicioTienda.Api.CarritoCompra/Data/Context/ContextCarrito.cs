using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.CarritoCompra.Modelo;

namespace ServicioTienda.Api.CarritoCompra.Data.Context
{
    public class ContextCarrito : DbContext
    {
        public ContextCarrito(DbContextOptions<ContextCarrito> options) : base(options)
        { }

        public DbSet<CarritoSesion> CarritoSesions { get; set; }

        public DbSet<CarritoSesionDetalle> CarritoSesionDetalles { get; set; }
    }
}
