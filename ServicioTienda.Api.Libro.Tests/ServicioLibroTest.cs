using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Comando.RegitrarLibro;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarLibroGuid;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Consultas.BuscarTodoLibro;
using ServicioTienda.Api.Libro.Aplicacion.Funcionalidades.Libros.Vm;
using ServicioTienda.Api.Libro.Data.Context;
using ServicioTienda.Api.Libro.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTienda.Api.Libro.Tests
{
    public class ServicioLibroTest
    {
        private  IEnumerable<Modelo.Libros> ObtenerDataPrueba()
        {
            A.Configure<Libros>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.Id, () => { return Guid.NewGuid(); });

            var lista =  A.ListOf<Libros>(30);
            lista[0].Id = Guid.Empty;

            return lista;
        }

        private Mock<ContextLibreria> CrearContexto ()
        {
            var datos =  ObtenerDataPrueba().AsQueryable();
            var dbSet = new Mock<DbSet<Libros>>();
            dbSet.As<IQueryable<Libros>>().Setup(x => x.Provider).Returns(datos.Provider);
            dbSet.As<IQueryable<Libros>>().Setup(x => x.Expression).Returns(datos.Expression);
            dbSet.As<IQueryable<Libros>>().Setup(x => x.GetEnumerator()).Returns(datos.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Libros>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new EnumeradorAsincronico<Libros>(datos.GetEnumerator()));

            dbSet.As<IQueryable<Libros>>().Setup(x => x.Provider).Returns(new ProveedorConsultasAsincronicas<Libros>(datos.Provider));

            var contexto = new Mock<ContextLibreria>();
            contexto.Setup(d => d.Libros).Returns(dbSet.Object);

            return contexto;
        }
        [Fact]
        public async void BuscarLibroPorId()
        {
            var mockContexto = CrearContexto();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapeoPerfil());
            });

            var map = mapConfig.CreateMapper();
            var guid = Guid.Empty;
            var request = new BuscarLibroGuidConsulta(guid);

            var handler = new BuscarLibroGuidHandler(mockContexto.Object, map);

            var libro = await handler.Handle(request, new CancellationToken());

            Assert.NotNull(libro);
            Assert.True(libro.Id == Guid.Empty);

        } 
        [Fact]
        public async void BuscarLibros()
        {
            var mockContext = CrearContexto();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapeoPerfil());
            });

            var map = mapConfig.CreateMapper();
            var handler = new BuscarTodoLibroHandler(mockContext.Object,map);

            var request = new BuscarTodoLibroConsulta();

            var resultado = await handler.Handle(request, new CancellationToken());

            Assert.True(resultado.Any());
        }
        [Fact]
        public async void GuardarLibro()
        {
            var options = new DbContextOptionsBuilder<ContextLibreria>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibro")
                .Options;

            var contexto = new ContextLibreria(options);

            var request = new RegistrarLibroComando();
            request.Titulo = "Libro de Microservice";
            request.AutorLibro = Guid.Empty;
            request.FechaPublicacion = DateTime.Now;

            var manejador = new RegistrarLibroHandler(contexto);

            var libro = await manejador.Handle(request, new CancellationToken());

            Assert.True(libro != null);
        }
    }
}
