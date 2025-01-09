using ServicioTienda.Api.Gateway.Externo.Interfaz;
using ServicioTienda.Api.Gateway.Externo.Vm;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace ServicioTienda.Api.Gateway.Handler.Libros
{
    public class LibroHandler : DelegatingHandler
    {
        private readonly ILogger<LibroHandler> _logger;
        private readonly IAutorExterno _autorExterno;
        public LibroHandler(ILogger<LibroHandler> logger, IAutorExterno autorExterno)
        {
            _logger = logger;
            _autorExterno = autorExterno;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var tiempo = Stopwatch.StartNew();
                _logger.LogInformation("Inicia el Request");
                var respuesta = await base.SendAsync(request, cancellationToken);
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    var opcion = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var resultado = JsonSerializer.Deserialize<LibroExterno>(contenido, opcion);
                    var respuestaAutor = await _autorExterno.BuscarAutor(resultado.Autor ?? Guid.Empty);
                    if (respuestaAutor.resultado)
                    {
                        var resultadostr = JsonSerializer.Serialize(resultado);
                        respuesta.Content = new StringContent("", Encoding.UTF8, "application/json");

                    }
                }
                _logger.LogInformation($"Este Proceso se hizo en {tiempo.ElapsedMilliseconds}ms");
                return respuesta;
            }
            catch (Exception ex)
            {
                var P = ex;
                throw;
            }
          
        }
    }
}
