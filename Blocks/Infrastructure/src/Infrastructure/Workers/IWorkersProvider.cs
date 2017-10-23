
namespace EntLibExtensions.Infrastructure.Workers
{
    using System.Collections.Generic;

    /// <summary>
    /// The WorkersHostConfiguration interface.
    /// </summary>
    public interface IWorkersProvider
    {
        /// <summary>
        /// Gets the workers.
        /// </summary>
        IEnumerable<IWorker> Workers { get; }
    }
}