using MediatR;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Consulta.BuscarAutorGuid
{
    public class BuscarAutorGuidConsulta : IRequest<AutorLibroVM>
    {
        public string AutorGuid { get; set; }
       

        public BuscarAutorGuidConsulta(string autorGuid)
        {
           
            if (autorGuid is null)
            {
                throw new ArgumentException("El ID del autor no puede estar vacio", nameof(autorGuid));
            }

            AutorGuid = autorGuid;
        }
    }
}
