
namespace EntLibExtensions.Infrastructure.Workers
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// The WorkerAction interface.
    /// </summary>
    public interface IWorkerAction
    {
        /// <summary>
        /// The run method .  
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// Returns true in case futher staf for processing is available
        /// </returns>
        bool Run(CancellationToken cancellationToken, IDictionary<string, string> parameters);
    }
}