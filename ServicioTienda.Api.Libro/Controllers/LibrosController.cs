using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Comando.RegitrarLibro;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarLibroGuid;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarTodoLibro;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;
using System.Net;

namespace ServicioTienda.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibrosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Registrar", Name = "RegistrarLibro")]
        [ProducesResponseType(typeof(Unit), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<Unit>> Registrar(RegistrarLibroComando comando)
        {
            return await _mediator.Send(comando);
        }
        [HttpGet("BuscarTodo", Name = "BuscarTodo")]
        [ProducesResponseType(typeof(List<LibroVm>), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<List<LibroVm>>> BuscarTodo()
        {
            var consulta = new BuscarTodoLibroConsulta();
            return await _mediator.Send(consulta);
        }

        [HttpGet("BuscarAutor", Name = "BuscarAutor")]
        [ProducesResponseType(typeof(LibroVm), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<LibroVm>> BuscarAutor(Guid? guid)
        {
            var consulta = new BuscarLibroGuidConsulta(guid);
            return await _mediator.Send(consulta);
        }

    }
}
