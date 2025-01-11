using ServicioTienda.Api.RabbitMQ.Bus.Data.Interfaz;
using ServicioTienda.Api.RabbitMQ.Bus.EventoCola;

namespace ServicioTienda.Api.Autor.ManejadorRabbit
{
    public class ManejadorEventoEmail : IEventoManejador<ColaEventosEmail>
    {
        private readonly ILogger<ManejadorEventoEmail> _logger;
        public ManejadorEventoEmail(ILogger<ManejadorEventoEmail> logger)
        {
            _logger = logger;
        }
        public Task Handle(ColaEventosEmail @event)
        {
            _logger.LogInformation($"Este es el valor que consumo de RabbitMQ {@event.Titulo}");

            return Task.CompletedTask;
        }
    }
}
