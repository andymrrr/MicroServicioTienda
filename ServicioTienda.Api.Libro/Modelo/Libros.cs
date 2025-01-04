namespace ServicioTienda.Api.Libro.Modelo
{
    public class Libros
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? Autor { get; set; }

    }
}
