using AutoMapper;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;
using ServicioTienda.Api.Libro.Modelo;

namespace ServicioTienda.Api.Libro.Tests
{
    public class MapeoPerfil :Profile
    {
        public MapeoPerfil()
        {
            CreateMap<Libreria, LibroVm>().ReverseMap();
        }
    }
}
