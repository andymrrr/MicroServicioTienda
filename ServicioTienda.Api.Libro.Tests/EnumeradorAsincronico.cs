namespace ServicioTienda.Api.Libro.Tests
{
  
        /// <summary>
        /// Implementa un enumerador asincrónico para iterar sobre una colección de tipo <typeparamref name="T"/>.
        /// Esta clase es útil para iterar de forma asincrónica sobre colecciones que se manejan con <see cref="IEnumerator{T}"/>.
        /// </summary>
        /// <typeparam name="T">Tipo de los elementos que se están enumerando.</typeparam>
        public class EnumeradorAsincronico<T> : IAsyncEnumerator<T>
        {
            // El enumerador sincrónico que se usará para iterar sobre los elementos
            private readonly IEnumerator<T> _enumerator;

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="EnumeradorAsincronico{T}"/> con el enumerador proporcionado.
            /// </summary>
            /// <param name="enumerator">El enumerador sincrónico a utilizar para la iteración.</param>
            /// <exception cref="ArgumentNullException">Se lanza si el enumerador proporcionado es null.</exception>
            public EnumeradorAsincronico(IEnumerator<T> enumerator)
            {
                // Verificamos que el enumerador no sea null
                _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
            }

            /// <summary>
            /// Obtiene el elemento actual de la colección que se está iterando.
            /// </summary>
            public T Current => _enumerator.Current;

            /// <summary>
            /// Libera los recursos utilizados por el enumerador de manera asincrónica.
            /// </summary>
            /// <returns>Un <see cref="ValueTask"/> que indica que la tarea ha finalizado.</returns>
            public ValueTask DisposeAsync()
            {
                // Se libera el recurso del enumerador sincrónico
                _enumerator.Dispose();
                return ValueTask.CompletedTask;
            }

            /// <summary>
            /// Avanza al siguiente elemento de la colección de manera asincrónica.
            /// </summary>
            /// <returns>Un <see cref="ValueTask{Boolean}"/> que indica si se avanzó al siguiente elemento.</returns>
            public ValueTask<bool> MoveNextAsync()
            {
                // Utilizamos MoveNext del enumerador sincrónico y lo envolvemos en un ValueTask
                return new ValueTask<bool>(_enumerator.MoveNext());
            }
        }
}
