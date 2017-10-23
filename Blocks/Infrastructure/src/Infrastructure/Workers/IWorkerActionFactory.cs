
namespace EntLibExtensions.Infrastructure.Workers
{
    using System;

    /// <summary>
    /// The WorkerActionFactory interface.
    /// </summary>
    public interface IWorkerActionFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="type">
        /// The action type.
        /// </param>
        /// <returns>
        /// The <see cref="IWorkerAction"/>.
        /// </returns>
        IWorkerAction Create(Type type);

        /// <summary>
        /// The cerate child factory.
        /// </summary>
        /// <returns>
        /// The <see cref="IWorkerActionFactory"/>.
        /// </returns>
        IWorkerActionFactory CerateChildFactory();
    }
}