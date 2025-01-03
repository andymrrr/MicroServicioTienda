using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Comando.CarritoSesiones;
using ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Consulta.BuscarCarrito;
using ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.Vm;
using System.Net;

namespace ServicioTienda.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarritoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Registrar", Name = "RegistrarCarrito")]
        [ProducesResponseType(typeof(Unit), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<Unit>> Registrar(RegistrarCarritoSesionComando comando)
        {
            return await _mediator.Send(comando);
        }

        [HttpGet("BuscarCarrito/{id}", Name = "BuscarCarrito")]
        [ProducesResponseType(typeof(CarritoVm), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<CarritoVm>> BuscarCarrito(int id)
        {
            var consulta = new BuscarCarritoConsulta(id);
            return await _mediator.Send(consulta);
        }
    }
}
