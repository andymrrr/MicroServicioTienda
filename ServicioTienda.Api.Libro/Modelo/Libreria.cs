namespace ServicioTienda.Api.Libro.Modelo
{
    public class Libreria
    {
        public Guid? LibreriaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }

    }
}
