using ServicioTienda.Api.Gateway.Externo.Interfaz;
using System.Text.Json;
using System;
using ServicioTienda.Api.Gateway.Externo.Vm;

namespace ServicioTienda.Api.Gateway.Externo.Repositorio
{
    public class RepositorioAutorExterno : IAutorExterno
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RepositorioAutorExterno> _logger;
        public RepositorioAutorExterno(IHttpClientFactory httpClientFactory, ILogger<RepositorioAutorExterno> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<(bool resultado, Vm.AutorExterno autor, string mensaje)> BuscarAutor(Guid AutorId)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient("ServicioAutor");
                var respuesta = await cliente.GetAsync($"/Autor/{AutorId}");
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    var opcion = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<AutorExterno>(contenido, opcion);

                    return (true, resultado, null);
                }

                return (false, null, respuesta.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
            throw new NotImplementedException();
        }
    }
}
