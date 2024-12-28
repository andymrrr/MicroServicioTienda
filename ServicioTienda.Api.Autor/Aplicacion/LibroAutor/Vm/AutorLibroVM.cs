using ServicioTienda.Api.Autor.Modelo;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm
{
    public class AutorLibroVM
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

       

        public string AutorlibroGuid { get; set; }
    }
}
