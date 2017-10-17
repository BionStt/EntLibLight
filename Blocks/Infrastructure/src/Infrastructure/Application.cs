namespace EntLibExtensions.Infrastructure
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using EntLibExtensions.Infrastructure.WinService;

    /// <summary>
    /// The application.
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// The run application.
        /// </summary>
        /// <typeparam name="T">
        /// The bootstrap state
        /// </typeparam>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="bootstrap">
        /// The bootstrap.
        /// </param>
        /// <param name="run">
        /// The run action.
        /// </param>
        public static void RunApplication<T>(string[] args, Func<string[], T> bootstrap, Action<string[], T> run)
        {
            InfraEventSource.Log.AppStartDefault();
            try
            {
                string[] argsSafe = args ?? new string[0];
                T state = bootstrap(argsSafe);
                run(argsSafe, state);
            }
            catch (Exception e)
            {
                InfraEventSource.Log.AppCriticalFailure(e);
                throw;
            }
            finally
            {
                InfraEventSource.Log.AppEndDefault();
            }
        }

        /// <summary>
        /// The run application async.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="bootstrap">
        /// The bootstrap.
        /// </param>
        /// <param name="run">
        /// The run.
        /// </param>
        /// <typeparam name="T">
        /// The bootstrap state
        /// </typeparam>
        public static void RunApplicationAsync<T>(string[] args, Func<string[], T> bootstrap, Func<string[], T, Task> run)
        {
            InfraEventSource.Log.AppStartDefault();
            try
            {
                string[] argsSafe = args ?? new string[0];
                T state = bootstrap(argsSafe);

                Task task = run(argsSafe, state);
                
                task.GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                InfraEventSource.Log.AppCriticalFailure(e);
                throw;
            }
            finally
            {
                InfraEventSource.Log.AppEndDefault();
            }
        }

        /// <summary>
        /// The run service.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="bootstrap">
        /// The factory.
        /// </param>
        public static void RunService(string[] args, Func<string[], IWinService> bootstrap)
        {
            RunApplication(args, bootstrap, RunService);           
        }

        /// <summary>
        /// The run service.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="winService">
        /// The win service.
        /// </param>
        private static void RunService(string[] args, IWinService winService)
        {
            DefaultService service = new DefaultService(winService);
            service.StartUp(args);
        }
    }
}