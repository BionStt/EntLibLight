namespace EntLibExtensions.Infrastructure.Samples
{
    using EntLibExtensions.Infrastructure;
    using EntLibExtensions.Infrastructure.Unity;
    using EntLibExtensions.Infrastructure.WinService;
    using EntLibExtensions.SemanticLogging;

    using global::Unity;

    using Microsoft.Diagnostics.Tracing;

    class Program
    {
        static void Main(string[] args)
        {
            // Subscribe for logging events. Not mandatory, however very useful
            ObservableEventListener listener = new ObservableEventListener();
            listener.EnableEvents(InfraEventSource.Log, EventLevel.LogAlways);
            listener.LogToConsole();

            // Run repeatable actions from configuration as windows service. 
            // Instances which implements IWorkerAction will be resolved from Unity Container
            Application application = new Application(args);
            application.RunWorkersHostService(
                strings => new WinServiceOptions("EntLibExtensions.Infrastructure.Samples"),
                strings => BootstrapContainer(strings));
        }

        private static IUnityContainer BootstrapContainer(string[] strings)
        {
            IUnityContainer container = new UnityContainer();

            // Actions have constructor without parameters, so simply register them in container
            container.RegisterType<Action1>();
            container.RegisterType<Action2>();

            return container;
        }
    }
}
