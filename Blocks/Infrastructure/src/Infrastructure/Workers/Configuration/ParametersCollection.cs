
namespace EntLibExtensions.Infrastructure.Workers.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The worker collection.
    /// </summary>
    public class ParametersCollection : ConfigurationElementCollection
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
        public ParameterConfig this[int index]
        {
            get
            {
                return (ParameterConfig)this.BaseGet(index);
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
        public void Add(ParameterConfig workerConfig)
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
        public void Remove(ParameterConfig workerConfig)
        {
            this.BaseRemove(workerConfig.Key);
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
            return new ParameterConfig();
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
            return ((ParameterConfig)element).Key;
        }
    }
}