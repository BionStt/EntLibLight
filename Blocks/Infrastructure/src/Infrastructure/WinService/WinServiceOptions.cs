namespace EntLibExtensions.Infrastructure.WinService
{
    using System;

    /// <summary>
    /// The win service options.
    /// </summary>
    public class WinServiceOptions
    {
        private readonly string serviceName;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinServiceOptions"/> class.
        /// </summary>
        /// <param name="serviceName">
        /// The service name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public WinServiceOptions(string serviceName)
        {
            if (serviceName == null)
            {
                throw new ArgumentNullException(nameof(serviceName));
            }

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                throw new ArgumentException("Name can't be null or whitespace", nameof(serviceName));
            }

            this.serviceName = serviceName;
        }

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
        public string ServiceName
        {
            get
            {
                return this.serviceName;
            }            
        }
    }
}