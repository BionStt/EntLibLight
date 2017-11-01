
namespace EntLibExtensions.Infrastructure.Workers.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EntLibExtensions.Infrastructure.Workers.Configuration;

    /// <summary>
    /// The worker configuration.
    /// </summary>
    public class WorkerActionConfiguration : IWorkerActionConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerActionConfiguration"/> class.
        /// </summary>
        /// <param name="workerConfig">
        /// The worker config.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        public WorkerActionConfiguration(WorkerConfig workerConfig)
        {
            if (workerConfig == null)
            {
                throw new ArgumentNullException(nameof(workerConfig));
            }

            this.ActionType = workerConfig.ActionType;
            this.ShortTimeout = TimeSpan.FromSeconds(workerConfig.ShortTimeoutSec);
            this.LongTimeout = TimeSpan.FromSeconds(workerConfig.LongTimeoutSec);
            this.FailTimeout = TimeSpan.FromSeconds(workerConfig.FailTimeoutSec);
            this.DelayStart = TimeSpan.FromSeconds(workerConfig.DelayStartSec);
            this.Parameters = workerConfig.Parameters.OfType<ParameterConfig>()
                .ToDictionary(config => config.Key, config => config.Value);
        }

        /// <summary>
        /// Gets the action type.
        /// </summary>
        public Type ActionType { get; }

        /// <summary>
        /// Gets the fail timeout.
        /// </summary>
        public TimeSpan FailTimeout { get; }

        /// <summary>
        /// Gets the long timeout.
        /// </summary>
        public TimeSpan LongTimeout { get; }

        /// <summary>
        /// Gets the short timeout.
        /// </summary>
        public TimeSpan ShortTimeout { get; }

        /// <summary>
        /// Gets the delay start.
        /// </summary>
        public TimeSpan DelayStart { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public IDictionary<string, string> Parameters { get; }
    }
}