namespace EntLibExtensions.Infrastructure.WinService
{
    using System;
    using System.ServiceProcess;

    /// <summary>
    /// The default service.
    /// </summary>
    public class DefaultService : ServiceBase
    {
        /// <summary>
        /// The win service.
        /// </summary>
        private readonly IWinService winService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultService"/> class.
        /// </summary>
        /// <param name="winService">
        /// The win service.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public DefaultService(IWinService winService)
        {
            if (winService == null)
            {
                throw new ArgumentNullException(nameof(winService));
            }

            if (winService.Options == null)
            {
                throw new ArgumentException("winService.Options can't be null", nameof(winService));
            }

            if (string.IsNullOrWhiteSpace(winService.Options.ServiceName))
            {
                throw new ArgumentException(
                    "winService.Options.ServiceName can't be null or whitespace",
                    nameof(winService));
            }

            this.winService = winService;

            this.CanHandlePowerEvent = winService.Options.CanHandlePowerEvent;
            this.CanHandleSessionChangeEvent = winService.Options.CanHandleSessionChangeEvent;
            this.CanShutdown = winService.Options.CanShutdown;
            this.CanStop = winService.Options.CanStop;
            this.CanPauseAndContinue = winService.Options.CanPauseAndContinue;
            
            this.ServiceName = winService.Options.ServiceName;
        }

        /// <summary>
        /// The start up.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public void StartUp(string[] args)
        {
            if (Environment.UserInteractive)
            {
                this.OnStart(args);
                Console.WriteLine("{0} was started. Press any key to stop it", this.ServiceName);
                Console.ReadKey();
                this.Stop();
            }
            else
            {
                ServiceBase.Run(this);
            }
        }
    }
}