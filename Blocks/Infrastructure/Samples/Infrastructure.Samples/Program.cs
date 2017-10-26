namespace EntLibExtensions.Infrastructure.Samples
{
    using System;

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
            ObservableEventListener listener = new ObservableEventListener();
            listener.EnableEvents(InfraEventSource.Log, EventLevel.LogAlways);
            listener.LogToConsole();

            Application application = new Application(args);
            application.RunWorkersHostService(
                strings => new WinServiceOptions("EntLibExtensions.Infrastructure.Samples"),
                strings =>
                    {
                        IUnityContainer container = new UnityContainer();
                        container.RegisterType<Action1>();
                        container.RegisterType<Action2>();
                        return container;
                    });
        }
    }
}
