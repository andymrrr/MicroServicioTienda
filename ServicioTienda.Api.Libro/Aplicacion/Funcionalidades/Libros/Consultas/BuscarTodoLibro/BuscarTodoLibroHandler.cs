using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;
using ServicioTienda.Api.Libro.Data.Context;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarTodoLibro
{
    public class BuscarTodoLibroHandler : IRequestHandler<BuscarTodoLibroConsulta, List<LibroVm>>
    {
        public readonly ContextLibreria _context;
        private readonly IMapper _mapper;
        public BuscarTodoLibroHandler(ContextLibreria context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<LibroVm>> Handle(BuscarTodoLibroConsulta request, CancellationToken cancellationToken)
        {
            var libros = await _context.Librerias.ToListAsync();
            var autoresVm = _mapper.Map<List<LibroVm>>(libros);
            return autoresVm;
        }
    }
}
