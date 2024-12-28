using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Libro.Modelo;

namespace ServicioTienda.Api.Libro.Data.Context
{
    public class ContextLibreria : DbContext
    {
        public ContextLibreria(DbContextOptions<ContextLibreria> options) : base(options)
        { }

        public DbSet<Libreria> Librerias { get; set; }
    }
}
