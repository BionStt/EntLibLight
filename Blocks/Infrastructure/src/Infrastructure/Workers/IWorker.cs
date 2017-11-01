namespace EntLibExtensions.Infrastructure.Workers
{
    using System.Threading;

    /// <summary>
    /// The ActionWorker interface.
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// The start up.
        /// </summary>
        /// <param name="cancellationToken">
        /// cancellation token
        /// </param>
        void StartUp(CancellationToken cancellationToken);
    }
}