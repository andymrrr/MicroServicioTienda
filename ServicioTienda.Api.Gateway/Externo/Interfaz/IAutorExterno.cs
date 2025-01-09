using ServicioTienda.Api.Gateway.Externo.Vm;

namespace ServicioTienda.Api.Gateway.Externo.Interfaz
{
    public interface IAutorExterno
    {
        Task<(bool resultado, AutorExterno autor, string mensaje)> BuscarAutor(Guid AutorId);
    }
}
