namespace EntLibExtensions.Infrastructure.Unity
{
    using System;

    using EntLibExtensions.Infrastructure;
    using EntLibExtensions.Infrastructure.WinService;

    using global::Unity;

    /// <summary>
    /// The application extensions.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// The run workers host service.
        /// </summary>
        /// <param name="application">
        /// The application.
        /// </param>
        /// <param name="optionsBootstrap">
        /// The options bootstrap.
        /// </param>
        /// <param name="bootstrapContainer">
        /// The bootstrap container.
        /// </param>
        public static void RunWorkersHostService(
            this Application application,
            Func<string[], WinServiceOptions> optionsBootstrap,
            Func<string[], IUnityContainer> bootstrapContainer)
        {
            application.RunWorkersHostService(
                optionsBootstrap,
                strings =>
                    {
                        IUnityContainer container = bootstrapContainer(strings);
                        return new UnityWorkerActionFactory(container);
                    });
        }
    }
}