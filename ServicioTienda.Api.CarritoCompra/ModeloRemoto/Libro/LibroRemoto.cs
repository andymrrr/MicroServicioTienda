namespace ServicioTienda.Api.CarritoCompra.ModeloRemoto.Libro
{
    public class LibroRemoto
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? Autor { get; set; }
    }
}
