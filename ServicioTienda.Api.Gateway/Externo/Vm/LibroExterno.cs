namespace ServicioTienda.Api.Gateway.Externo.Vm
{
    public class LibroExterno
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public Guid? Autor { get; set; }

        public AutorExterno AutorData { get; set; }
    }
}
