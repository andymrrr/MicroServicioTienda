using FluentValidation;

namespace ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Comando.RegitrarLibro
{
    public class RegistrarLibroValidador : AbstractValidator<RegistrarLibroComando>
    {
        public RegistrarLibroValidador()
        {
            RuleFor(r => r.Titulo).NotEmpty();
            RuleFor(r => r.FechaPublicacion).NotEmpty();
            RuleFor(r => r.AutorLibro).NotEmpty();
        }
    }
}
