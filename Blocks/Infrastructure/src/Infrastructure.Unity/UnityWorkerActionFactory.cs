
namespace EntLibExtensions.Infrastructure.Unity
{
    using System;

    using EntLibExtensions.Infrastructure.Workers;

    using global::Unity;

    /// <summary>
    /// The worker action factory.
    /// </summary>
    public class UnityWorkerActionFactory : IWorkerActionFactory, IDisposable
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityWorkerActionFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityWorkerActionFactory(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="theType">
        /// The type to be created.
        /// </param>
        /// <returns>
        /// The created instance
        /// </returns>
        public IWorkerAction Create(Type theType)
        {            
            return (IWorkerAction)this.container.Resolve(theType);
        }

        /// <summary>
        /// The cerate child factory.
        /// </summary>
        /// <returns>
        /// The <see cref="IWorkerActionFactory"/>.
        /// </returns>
        public IWorkerActionFactory CerateChildFactory()
        {
            return new UnityWorkerActionFactory(this.container.CreateChildContainer());
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.container.Dispose();
            }
        }
    }
}