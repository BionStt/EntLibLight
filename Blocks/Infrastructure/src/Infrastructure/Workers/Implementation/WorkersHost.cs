
namespace EntLibExtensions.Infrastructure.Workers.Implementation
{
    using System;
    using System.Threading;

    /// <summary>
    /// The workers host.
    /// </summary>
    public class WorkersHost : IWorkersHost
    {
        /// <summary>
        /// The host configuration.
        /// </summary>
        private readonly IWorkersProvider provider;

        /// <summary>
        /// The cancellation token source.
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;        

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkersHost" /> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="cancellationTokenSource">The cancellation token source.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if provider or cancellation token source is null.
        /// </exception>
        public WorkersHost(IWorkersProvider provider, CancellationTokenSource cancellationTokenSource)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.provider = provider;
            this.cancellationTokenSource = cancellationTokenSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkersHost"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public WorkersHost(IWorkersProvider provider)
            : this(provider, null)
        {
        }

        /// <summary>
        /// The pause.
        /// </summary>
        public void Pause()
        {
            InfraEventSource.Log.HostPause();
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// The resume.
        /// </summary>
        public void Resume()
        {
            InfraEventSource.Log.HostResume();
            this.RunWorkers();
        }

        /// <summary>
        /// The shutdown.
        /// </summary>
        public void Shutdown()
        {
            InfraEventSource.Log.HostShutdown();
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// The start.
        /// </summary>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public void Start(string[] args)
        {
            InfraEventSource.Log.HostStart(AppDomain.CurrentDomain.FriendlyName);
            this.RunWorkers();
        }

        /// <summary>
        /// The stop method.
        /// </summary>
        public void Stop()
        {
            InfraEventSource.Log.HostStop(AppDomain.CurrentDomain.FriendlyName);
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// The run workers.
        /// </summary>
        private void RunWorkers()
        {
            this.cancellationTokenSource = this.cancellationTokenSource ?? new CancellationTokenSource();

            foreach (IWorker worker in this.provider.Workers)
            {
                worker.StartUp(this.cancellationTokenSource.Token);
            }
        }
    }
}