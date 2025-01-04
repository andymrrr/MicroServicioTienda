namespace ServicioTienda.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public ICollection<GradoAcademico> gradoAcademicos { get; set; }

        public string AutorlibroGuid { get; set; }
    }
}
