namespace EntLibExtensions.Infrastructure.WinService
{
    /// <summary>
    /// The WinService interface.
    /// </summary>
    public interface IWinService
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        WinServiceOptions Options { get; }

        /// <summary>
        /// The on continue.
        /// </summary>
        void OnContinue();

        /// <summary>
        /// The on pause.
        /// </summary>
        void OnPause();

        /// <summary>
        /// The on shutdown.
        /// </summary>
        void OnShutdown();

        /// <summary>
        /// The on start.
        /// </summary>
        /// <param name="args">
        /// The args which passed to start routine.
        /// </param>
        void OnStart(string[] args);

        /// <summary>
        /// The on stop.
        /// </summary>
        void OnStop();
    }
}