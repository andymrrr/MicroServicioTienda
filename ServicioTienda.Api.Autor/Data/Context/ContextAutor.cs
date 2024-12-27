using Microsoft.EntityFrameworkCore;
using ServicioTienda.Api.Autor.Modelo;

namespace ServicioTienda.Api.Autor.Data.Context
{
    public class ContextAutor : DbContext
    {
        public ContextAutor(DbContextOptions<ContextAutor> options) : base(options) 
        { }

        public DbSet<AutorLibro> AutorLibros { get; set; }

        public DbSet<GradoAcademico> GradoAcademicos { get; set; }
    }
}
