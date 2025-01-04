namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm
{
    public class LibroVm
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
