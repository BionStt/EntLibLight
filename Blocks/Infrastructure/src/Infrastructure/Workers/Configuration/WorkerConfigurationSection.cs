
namespace EntLibExtensions.Infrastructure.Workers.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The worker configuration section.
    /// </summary>
    public class WorkerConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the workers.
        /// </summary>
        [ConfigurationProperty("Actions", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(WorkerCollection), AddItemName = "add", ClearItemsName = "clear", 
            RemoveItemName = "remove")]
        public WorkerCollection WorkerActions => (WorkerCollection)base["Actions"];
    }
}