using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioTienda.Api.Libro.Tests
{
    /// <summary>
    /// Implementa el proveedor de consultas asincrónicas para proporcionar soporte a consultas LINQ 
    /// asincrónicas a través de un proveedor de consultas interno.
    /// </summary>
    /// <typeparam name="TEntity">Tipo de la entidad sobre la que se realizarán las consultas.</typeparam>
    public class ProveedorConsultasAsincronicas<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProveedorConsultasAsincronicas{TEntity}"/> 
        /// con un proveedor de consultas interno.
        /// </summary>
        /// <param name="inner">Proveedor de consultas que maneja la ejecución de las consultas.</param>
        public ProveedorConsultasAsincronicas(IQueryProvider inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        /// <summary>
        /// Crea una consulta asincrónica basada en la expresión proporcionada.
        /// </summary>
        public IQueryable CreateQuery(Expression expression)
        {
            return new EnumerableAsincrono<TEntity>(expression);
        }

        /// <summary>
        /// Crea una consulta asincrónica con un tipo específico.
        /// </summary>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new EnumerableAsincrono<TElement>(expression);
        }

        /// <summary>
        /// Ejecuta una consulta sincrónica basada en la expresión proporcionada.
        /// </summary>
        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        /// <summary>
        /// Ejecuta una consulta sincrónica y devuelve un resultado de tipo específico.
        /// </summary>
        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        /// <summary>
        /// Ejecuta una consulta asincrónica y devuelve un resultado de tipo específico.
        /// </summary>
        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var executionResult = typeof(IQueryProvider)
                .GetMethod(nameof(IQueryProvider.Execute), 1, new[] { typeof(Expression) })
                ?.MakeGenericMethod(expectedResultType)
                .Invoke(_inner, new[] { expression });

            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))
                ?.MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] { executionResult });
        }
    }
}
