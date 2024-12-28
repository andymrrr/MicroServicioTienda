using MediatR;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Consulta.BuscarTodosAutores
{
    public class BuscarTodosAutoresConsulta: IRequest<List<AutorLibroVM>>
    {

    }
}
