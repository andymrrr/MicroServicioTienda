using System.Linq.Expressions;

namespace ServicioTienda.Api.Libro.Tests
{
    public class EnumerableAsincrono<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public EnumerableAsincrono(IEnumerable<T> enumerable) : base(enumerable) { }

        public EnumerableAsincrono(Expression expression) : base(expression) { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new EnumeradorAsincronico<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider => new ProveedorConsultasAsincronicas<T>(this);
    }
}
