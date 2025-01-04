using AutoMapper;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;
using ServicioTienda.Api.Libro.Modelo;

namespace ServicioTienda.Api.Libro.Mapper
{
    public class MapeoPerfil :Profile
    {
        public MapeoPerfil()
        {
            CreateMap<Libros, LibroVm>().ReverseMap();
        }
    }
}
