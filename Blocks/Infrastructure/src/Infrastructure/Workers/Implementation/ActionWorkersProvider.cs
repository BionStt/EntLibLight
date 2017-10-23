// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ActionWorkersProvider.cs">
//   Copyright © 2017 Ihar Yakimush.
// </copyright>
// <summary>
//   The workers host configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EntLibExtensions.Infrastructure.Workers.Implementation
{
    using System;
    using System.Collections.Generic;

    using EntLibExtensions.Infrastructure.Workers.Configuration;

    /// <summary>
    /// The workers host configuration.
    /// </summary>
    public class ActionWorkersProvider : IWorkersProvider
    {
        /// <summary>
        /// The worker action factory.
        /// </summary>
        private readonly IWorkerActionFactory workerActionFactory;

        /// <summary>
        /// The workers.
        /// </summary>
        private readonly IEnumerable<IWorkerActionConfiguration> workers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWorkersProvider" /> class.
        /// </summary>
        /// <param name="workerConfigurationSection">The worker configuration section.</param>
        /// <param name="workerActionFactory">The worker Action Factory.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if any argument is null.
        /// </exception>
        public ActionWorkersProvider(WorkerConfigurationSection workerConfigurationSection, IWorkerActionFactory workerActionFactory)
        {
            if (workerConfigurationSection == null)
            {
                throw new ArgumentNullException(nameof(workerConfigurationSection));
            }

            if (workerActionFactory == null)
            {
                throw new ArgumentNullException(nameof(workerActionFactory));
            }
            
            this.workerActionFactory = workerActionFactory;

            IList<IWorkerActionConfiguration> workersList = new List<IWorkerActionConfiguration>();

            foreach (WorkerConfig workerConfiguration in workerConfigurationSection.WorkerActions)
            {
                workersList.Add(new WorkerActionConfiguration(workerConfiguration));
            }

            this.workers = workersList;
        }

        /// <summary>
        /// Gets the workers.
        /// </summary>
        public IEnumerable<IWorker> Workers
        {
            get
            {
                foreach (IWorkerActionConfiguration cfg in this.workers)
                {
                    yield return new ActionWorker(cfg, this.workerActionFactory);
                }                
            }
        }
    }
}