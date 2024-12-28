using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Vm;
using ServicioTienda.Api.Autor.Data.Context;
using ServicioTienda.Api.Autor.Modelo;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Consulta.BuscarAutorGuid
{
    public class BuscarAutorGuidHandler : IRequestHandler<BuscarAutorGuidConsulta, AutorLibroVM>
    {
        private readonly ContextAutor _context;
        private readonly IMapper _mapper;
        public BuscarAutorGuidHandler(ContextAutor context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AutorLibroVM> Handle(BuscarAutorGuidConsulta request, CancellationToken cancellationToken)
        {
            var autor = await _context.AutorLibros.Where(d => d.AutorlibroGuid == request.AutorGuid).FirstOrDefaultAsync();

            if (autor is null) {
                throw new Exception("El autor no se encuentra");
            }
            var autorVm = _mapper.Map<AutorLibroVM>(autor);

            return autorVm;
        }
    }
}
