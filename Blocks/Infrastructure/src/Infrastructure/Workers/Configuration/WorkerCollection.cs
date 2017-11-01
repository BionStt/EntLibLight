
namespace EntLibExtensions.Infrastructure.Workers.Configuration
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The worker collection.
    /// </summary>
    public class WorkerCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// The accessor to the collection element.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="WorkerConfig"/>.
        /// </returns>
        public WorkerConfig this[int index]
        {
            get
            {
                return (WorkerConfig)this.BaseGet(index);
            }

            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        }
        
        /// <summary>
        /// Adds to collection.
        /// </summary>
        /// <param name="workerConfig">
        /// The worker config.
        /// </param>
        public void Add(WorkerConfig workerConfig)
        {
            this.BaseAdd(workerConfig);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.BaseClear();
        }

        /// <summary>
        /// Removes from collection.
        /// </summary>
        /// <param name="workerConfig">
        /// The worker config.
        /// </param>
        public void Remove(WorkerConfig workerConfig)
        {
            this.BaseRemove(workerConfig.ActionType);
        }

        /// <summary>
        /// Removes from collection.
        /// </summary>
        /// <param name="name">
        /// The name of action to be removed.
        /// </param>
        public void Remove(string name)
        {
            this.BaseRemove(name);
        }

        /// <summary>
        /// The remove at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }
        
        /// <summary>
        /// The create new element.
        /// </summary>
        /// <returns>
        /// The <see cref="ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new WorkerConfig();
        }

        /// <summary>
        /// The get element key.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {            
            return Guid.NewGuid().ToString("N");
        }
    }
}