using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTienda.Api.CarritoCompra.Aplicacion.Funcionalidad.CarritoSesiones;
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
    }
}
