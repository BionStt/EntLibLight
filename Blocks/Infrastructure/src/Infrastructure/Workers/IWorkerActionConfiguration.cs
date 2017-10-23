
namespace EntLibExtensions.Infrastructure.Workers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The WorkerConfiguration interface.
    /// </summary>
    public interface IWorkerActionConfiguration
    {
        /// <summary>
        /// Gets the action type.
        /// </summary>
        Type ActionType { get; }

        /// <summary>
        /// Gets the fail timeout.
        /// </summary>
        TimeSpan FailTimeout { get; }

        /// <summary>
        /// Gets the long timeout.
        /// </summary>
        TimeSpan LongTimeout { get; }

        /// <summary>
        /// Gets the short timeout.
        /// </summary>
        TimeSpan ShortTimeout { get; }

        /// <summary>
        /// Gets the delay start.
        /// </summary>
        TimeSpan DelayStart { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}