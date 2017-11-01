
namespace EntLibExtensions.Infrastructure.Workers.Configuration
{
    using System;
    using System.ComponentModel;
    using System.Configuration;

    /// <summary>
    /// The worker config.
    /// </summary>
    public class WorkerConfig : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the action type.
        /// </summary>
        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("ActionType", DefaultValue = null, IsRequired = true, IsKey = false)]
        public Type ActionType
        {
            get
            {
                return (Type)this["ActionType"];
            }

            set
            {
                this["ActionType"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the fail timeout sec.
        /// </summary>
        [ConfigurationProperty("FailTimeoutSec", DefaultValue = "10", IsRequired = true, IsKey = false)]
        public int FailTimeoutSec
        {
            get
            {
                return (int)this["FailTimeoutSec"];
            }

            set
            {
                this["FailTimeoutSec"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the long timeout sec.
        /// </summary>
        [ConfigurationProperty("LongTimeoutSec", DefaultValue = "10", IsRequired = true, IsKey = false)]
        public int LongTimeoutSec
        {
            get
            {
                return (int)this["LongTimeoutSec"];
            }

            set
            {
                this["LongTimeoutSec"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the short timeout sec.
        /// </summary>
        [ConfigurationProperty("ShortTimeoutSec", DefaultValue = "10", IsRequired = true, IsKey = false)]
        public int ShortTimeoutSec
        {
            get
            {
                return (int)this["ShortTimeoutSec"];
            }

            set
            {
                this["ShortTimeoutSec"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the short timeout sec.
        /// </summary>
        [ConfigurationProperty("DelayStartSec", DefaultValue = "0", IsRequired = false, IsKey = false)]
        public int DelayStartSec
        {
            get
            {
                return (int)this["DelayStartSec"];
            }

            set
            {
                this["DelayStartSec"] = value;
            }
        }

        /// <summary>
        /// Gets the workers.
        /// </summary>
        [ConfigurationProperty("parameters", IsDefaultCollection = false, IsRequired = false)]
        [ConfigurationCollection(typeof(ParametersCollection), AddItemName = "add", ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ParametersCollection Parameters
        {
            get
            {
                return (ParametersCollection)base["parameters"];
            }
        }
    }
}