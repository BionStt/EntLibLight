namespace EntLibExtensions.Infrastructure.WinService
{
    using System;

    using EntLibExtensions.Infrastructure.Workers;

    /// <summary>
    /// The workers host win service.
    /// </summary>
    public class WorkersHostWinService : IWinService
    {
        /// <summary>
        /// The workers host.
        /// </summary>
        private readonly IWorkersHost workersHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkersHostWinService"/> class.
        /// </summary>
        /// <param name="workersHost">
        /// The workers host.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        public WorkersHostWinService(IWorkersHost workersHost, WinServiceOptions options)
        {
            if (workersHost == null)
            {
                throw new ArgumentNullException(nameof(workersHost));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.workersHost = workersHost;
            this.Options = options;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public WinServiceOptions Options { get; }

        /// <summary>
        /// The on continue.
        /// </summary>
        public void OnContinue()
        {
            this.workersHost.Resume();
        }

        /// <summary>
        /// The on pause.
        /// </summary>
        public void OnPause()
        {
            this.workersHost.Pause();
        }

        /// <summary>
        /// The on shutdown.
        /// </summary>
        public void OnShutdown()
        {
            this.workersHost.Shutdown();
        }

        /// <summary>
        /// The on start.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public void OnStart(string[] args)
        {
            this.workersHost.Start(args);
        }

        /// <summary>
        /// The on stop.
        /// </summary>
        public void OnStop()
        {
            this.workersHost.Stop();
        }
    }
}