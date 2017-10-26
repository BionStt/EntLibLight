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
        /// Argument Null Exception
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

        /// <summary>
        /// The on start.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        protected override void OnStart(string[] args)
        {
            this.winService.OnStart(args);
        }

        /// <summary>
        /// The on continue.
        /// </summary>
        protected override void OnContinue()
        {
            this.winService.OnContinue();
        }

        /// <summary>
        /// The on pause.
        /// </summary>
        protected override void OnPause()
        {
            this.winService.OnPause();
        }

        /// <summary>
        /// The on stop.
        /// </summary>
        protected override void OnStop()
        {
            this.winService.OnStop();
        }

        /// <summary>
        /// The on shutdown.
        /// </summary>
        protected override void OnShutdown()
        {
            this.winService.OnShutdown();
        }
    }
}