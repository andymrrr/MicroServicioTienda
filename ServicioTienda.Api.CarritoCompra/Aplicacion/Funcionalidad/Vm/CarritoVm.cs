namespace ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Vm
{
    public class CarritoVm
    {
        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public List<CarritoDetalleVm> CarritoDetalles { get; set; }
    }
}
