
namespace EntLibExtensions.Infrastructure.Workers.Implementation
{
    using System;
    using System.Threading;

    /// <summary>
    /// base class for workers
    /// </summary>
    public abstract class Worker : IWorker
    {
        /// <summary>
        ///     Gets the token.
        /// </summary>
        protected CancellationToken Token { get; private set; }

        /// <summary>
        /// The start up.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        public void StartUp(CancellationToken cancellationToken)
        {
            if (cancellationToken == null)
            {
                throw new ArgumentNullException(nameof(cancellationToken));
            }

            this.Token = cancellationToken;

            this.OnStartUp();
        }

        /// <summary>
        /// The on start up.
        /// </summary>
        protected abstract void OnStartUp();
    }
}