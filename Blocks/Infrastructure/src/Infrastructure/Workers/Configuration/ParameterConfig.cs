namespace EntLibExtensions.Infrastructure.Workers.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The worker config.
    /// </summary>
    public class ParameterConfig : ConfigurationElement
    {        
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get
            {
                return (string)this["key"];
            }

            set
            {
                this["key"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true, IsKey = false)]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }

            set
            {
                this["value"] = value;
            }
        }
    }
}