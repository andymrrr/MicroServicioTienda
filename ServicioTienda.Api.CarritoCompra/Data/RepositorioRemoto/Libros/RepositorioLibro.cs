using ServicioTienda.Api.CarritoCompra.Data.InterfazRemota.Libro;
using ServicioTienda.Api.CarritoCompra.ModeloRemoto.Libro;
using System.Text.Json;

namespace ServicioTienda.Api.CarritoCompra.Data.RepositorioRemoto.Libros
{
    public class RepositorioLibro : InterfazLibro
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RepositorioLibro> _logger;
        public RepositorioLibro(IHttpClientFactory httpClientFactory, ILogger<RepositorioLibro> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }   

        public async Task<(bool resultado, LibroRemoto libro, string mensajeError)> BuscarLibro(Guid guid)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient("libros");
                var respuesta = await cliente.GetAsync($"/api/Libros/BuscarLibro/{guid}");
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    var opcion = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemoto>(contenido, opcion);

                    return (true, resultado, null);
                }

                return (false, null, respuesta.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
           
        }
    }
}
