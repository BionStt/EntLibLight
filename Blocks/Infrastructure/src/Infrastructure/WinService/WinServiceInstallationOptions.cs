namespace EntLibExtensions.Infrastructure.WinService
{
    using System;
    using System.ServiceProcess;

    /// <summary>
    /// The win service installation options.
    /// </summary>
    public class WinServiceInstallationOptions
    {
        private string description;

        private string displayName;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinServiceInstallationOptions"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        public WinServiceInstallationOptions(WinServiceOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.Options = options;
        }

        /// <summary>
        /// Gets the service definition.
        /// </summary>
        public WinServiceOptions Options { get; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public ServiceAccount Account { get; set; } = ServiceAccount.User;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description ?? this.Options.ServiceName;
            }
            set
            {
                this.description = value;
            }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName
        {
            get
            {
                return this.displayName ?? this.Options.ServiceName;
            }
            set
            {
                this.displayName = value;
            }
        }
    }
}