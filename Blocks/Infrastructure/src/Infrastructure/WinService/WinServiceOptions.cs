namespace EntLibExtensions.Infrastructure.WinService
{
    /// <summary>
    /// The win service options.
    /// </summary>
    public class WinServiceOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether can handle power event.
        /// </summary>
        public bool CanHandlePowerEvent { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether can handle session change event.
        /// </summary>
        public bool CanHandleSessionChangeEvent { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether can shutdown.
        /// </summary>
        public bool CanShutdown { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether can stop.
        /// </summary>
        public bool CanStop { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether can pause and continue.
        /// </summary>
        public bool CanPauseAndContinue { get; set; } = false;

        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        public string ServiceName { get; set; }
    }
}