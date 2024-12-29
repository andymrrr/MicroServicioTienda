namespace ServicioTienda.Api.CarritoCompra.ModeloRemoto.Libro
{
    public class LibroRemoto
    {
        public Guid? LibreriaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
