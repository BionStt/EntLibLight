namespace EntLibExtensions.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    using EntLibExtensions.Infrastructure.WinService;
    using EntLibExtensions.Infrastructure.Workers;
    using EntLibExtensions.Infrastructure.Workers.Configuration;
    using EntLibExtensions.Infrastructure.Workers.Implementation;

    /// <summary>
    /// The application.
    /// </summary>
    public class Application
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public Application(string[] args)
        {
            this.Args = args ?? new string[0];
        }

        /// <summary>
        /// Gets the args.
        /// </summary>
        public string[] Args { get; }

        /// <summary>
        /// The run application.
        /// </summary>
        /// <typeparam name="T">
        /// The bootstrap state
        /// </typeparam>
        /// <param name="bootstrap">
        /// The bootstrap.
        /// </param>
        /// <param name="run">
        /// The run action.
        /// </param>
        public void RunApplication<T>(Func<string[], T> bootstrap, Action<string[], T> run)
        {
            InfraEventSource.Log.AppStartDefault();
            try
            {                
                T state = bootstrap(this.Args);
                run(this.Args, state);
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
        /// <param name="bootstrap">
        /// The bootstrap.
        /// </param>
        /// <param name="run">
        /// The run.
        /// </param>
        /// <typeparam name="T">
        /// The bootstrap state
        /// </typeparam>
        public void RunApplicationAsync<T>(Func<string[], T> bootstrap, Func<string[], T, Task> run)
        {
            InfraEventSource.Log.AppStartDefault();
            try
            {                
                T state = bootstrap(this.Args);

                Task task = run(this.Args, state);
                
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
        /// <param name="bootstrap">
        /// The factory.
        /// </param>
        public void RunService(Func<string[], IWinService> bootstrap)
        {
            this.RunApplication(bootstrap, RunService);           
        }

        /// <summary>
        /// The run workers host service.
        /// </summary>
        /// <param name="optionsBootstrap">
        /// The options.
        /// </param>
        /// <param name="providerBootstrap">
        /// The bootstrap.
        /// </param>
        public void RunWorkersHostService(Func<string[], WinServiceOptions> optionsBootstrap, Func<string[], IWorkersProvider> providerBootstrap)
        {
            this.RunApplication(
                delegate(string[] strings)
                    {
                        IWorkersProvider workersProvider = providerBootstrap(strings);
                        WinServiceOptions options = optionsBootstrap(strings);
                        return new Tuple<IWorkersProvider, WinServiceOptions>(workersProvider, options);
                    },
                RunWorkersHost);
        }

        /// <summary>
        /// The run workers host service.
        /// </summary>
        /// <param name="optionsBootstrap">
        /// The options bootstrap.
        /// </param>
        /// <param name="actionFactoryBootstrap">
        /// The action factory bootstrap.
        /// </param>
        public void RunWorkersHostService(Func<string[], WinServiceOptions> optionsBootstrap, Func<string[], IWorkerActionFactory> actionFactoryBootstrap)
        {
            this.RunWorkersHostService(
                optionsBootstrap,
                delegate(string[] strings)
                    {
                        IWorkerActionFactory actionFactory = actionFactoryBootstrap(strings);
                        return new ActionWorkersProvider(
                            new WorkerConfigurationSection(),
                            actionFactory);
                    });
        }

        /// <summary>
        /// The run workers host.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <param name="providerAndOptions">
        /// The provider and options.
        /// </param>
        private static void RunWorkersHost(string[] args, Tuple<IWorkersProvider, WinServiceOptions> providerAndOptions)
        {
            WorkersHostWinService service =
                new WorkersHostWinService(new WorkersHost(providerAndOptions.Item1), providerAndOptions.Item2);
            RunService(args, service);
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