
namespace EntLibExtensions.Infrastructure.Workers
{
    /// <summary>
    /// The WorkersHost interface.
    /// </summary>
    public interface IWorkersHost
    {
        /// <summary>
        /// The pause.
        /// </summary>
        void Pause();
        
        /// <summary>
        /// The resume.
        /// </summary>
        void Resume();

        /// <summary>
        /// The shutdown.
        /// </summary>
        void Shutdown();

        /// <summary>
        /// The start.
        /// </summary>
        /// <param name="args">
        /// The arguments.
        /// </param>
        void Start(string[] args);

        /// <summary>
        /// The stop method.
        /// </summary>
        void Stop();
    }
}