using ServicioTienda.Api.CarritoCompra.ModeloRemoto.Libro;

namespace ServicioTienda.Api.CarritoCompra.Data.InterfazRemota.Libro
{
    public interface InterfazLibro
    {
       Task<(bool resultado, LibroRemoto libro, string mensajeError)> BuscarLibro(Guid guid);
    }
}
