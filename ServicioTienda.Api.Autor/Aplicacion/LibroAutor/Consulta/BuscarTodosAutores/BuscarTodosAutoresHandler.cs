using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm;
using ServicioTienda.Api.Autor.Data.Context;
using ServicioTienda.Api.Autor.Modelo;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Consulta.BuscarTodosAutores
{
    public class BuscarTodosAutoresHandler : IRequestHandler<BuscarTodosAutoresConsulta, List<AutorLibroVM>>
    {
        private readonly ContextAutor _context;
        private readonly IMapper _mapper;
        public BuscarTodosAutoresHandler(ContextAutor context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AutorLibroVM>> Handle(BuscarTodosAutoresConsulta request, CancellationToken cancellationToken)
        {

            var autores = await _context.AutorLibros.ToListAsync();
            var autoresVm = _mapper.Map<List<AutorLibroVM>>(autores);
            return autoresVm;
        }
    }
}
