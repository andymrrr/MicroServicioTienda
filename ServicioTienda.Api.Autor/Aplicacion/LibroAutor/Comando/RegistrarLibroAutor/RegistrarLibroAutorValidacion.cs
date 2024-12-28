using FluentValidation;

namespace ServicioTienda.Api.Autor.Aplicacion.LibroAutor.Comando.RegistrarLibroAutor
{
    public class RegistrarLibroAutorValidacion : AbstractValidator<RegistrarLibroAutorComando>
    {
        public RegistrarLibroAutorValidacion()
        {
            RuleFor(r => r.Nombre).NotEmpty();
            RuleFor(r => r.Apellido).NotEmpty();


        }
    }
}
