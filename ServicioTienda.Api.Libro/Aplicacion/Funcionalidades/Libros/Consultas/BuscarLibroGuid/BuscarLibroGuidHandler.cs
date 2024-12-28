using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;
using ServicioTienda.Api.Libro.Data.Context;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarLibroGuid
{
    public class BuscarLibroGuidHandler : IRequestHandler<BuscarLibroGuidConsulta, LibroVm>
    {
        public readonly ContextLibreria _context;
        private readonly IMapper _mapper;
        public BuscarLibroGuidHandler(ContextLibreria context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<LibroVm> Handle(BuscarLibroGuidConsulta request, CancellationToken cancellationToken)
        {
            var autor = await _context.Librerias.Where(d => d.LibreriaId == request.LibroGuid).FirstOrDefaultAsync();

            if (autor is null)
            {
                throw new Exception("El autor no se encuentra");
            }
            var autorVm = _mapper.Map<LibroVm>(autor);

            return autorVm;
        }
    }
}
