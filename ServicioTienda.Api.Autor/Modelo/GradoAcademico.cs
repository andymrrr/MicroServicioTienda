namespace ServicioTienda.Api.Autor.Modelo
{
    public class GradoAcademico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CentroAcademico { get; set; }
        public DateTime? FechaGrado { get; set; }

        public int ibroId { get; set; }

        public AutorLibro AutorLibro { get; set; }

        public string GradoAcademicoGuid { get; set; }

    }
}
