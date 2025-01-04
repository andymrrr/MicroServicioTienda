using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Libro.Modelo;

namespace ServicioTienda.Api.Libro.Data.Context
{
    public class ContextLibreria : DbContext
    {
        public ContextLibreria()
        {
                
        }
        public ContextLibreria(DbContextOptions<ContextLibreria> options) : base(options)
        { }

        public virtual DbSet<Modelo.Libros> Libros { get; set; }
    }
}
