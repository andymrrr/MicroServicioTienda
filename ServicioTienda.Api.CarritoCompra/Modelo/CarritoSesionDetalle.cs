namespace ServicioTienda.Api.CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {
        public int CarritoSesionDetalleId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int CarritoSesionId { get; set; }
        public string libroSeleccionado { get; set; }

        public CarritoSesion CarritoSesion { get; set; }

    }
}
