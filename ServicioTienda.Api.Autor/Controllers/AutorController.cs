using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Comando.RegistrarLibroAutor;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Consulta.BuscarAutorGuid;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Consulta.BuscarTodosAutores;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm;
using ServicioTienda.Api.Autor.Modelo;
using System.Net;

namespace ServicioTienda.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Registrar", Name = "RegistrarAutor")]
        [ProducesResponseType(typeof(Unit), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<Unit>> Registrar (RegistrarLibroAutorComando comando)
        {
            return await _mediator.Send(comando);
        }

        [HttpGet("BuscarTodo", Name = "BuscarTodo")]
        [ProducesResponseType(typeof(List<AutorLibroVM>), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<List<AutorLibroVM>>> BuscarTodo()
        {
            var consulta = new BuscarTodosAutoresConsulta();
            return await _mediator.Send(consulta);
        }
        [HttpGet("BuscarAutor", Name = "BuscarAutor")]
        [ProducesResponseType(typeof(AutorLibroVM), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<AutorLibroVM>> BuscarAutor(string guid)
        {
            var consulta = new BuscarAutorGuidConsulta(guid);
            return await _mediator.Send(consulta);
        }
    }
}
