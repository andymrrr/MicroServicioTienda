using MediatR;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarTodoLibro
{
    public class BuscarTodoLibroConsulta : IRequest<List<LibroVm>>
    {
    }
}
