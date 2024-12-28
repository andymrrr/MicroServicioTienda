using AutoMapper;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm;
using ServicioTienda.Api.Autor.Modelo;

namespace ServicioTienda.Api.Autor.Mapper
{
    public class MapeoPerfil : Profile
    {
        public MapeoPerfil()
        {
            CreateMap<AutorLibroVM, AutorLibro>().ReverseMap();
        }
    }
}
