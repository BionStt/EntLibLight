﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntLibExtensions.SemanticLogging.Etw.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EntLibExtensions.SemanticLogging.Etw.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The event source id &apos;{0}&apos; is duplicated in the sink &apos;{1}&apos;..
        /// </summary>
        internal static string DuplicateEventSourceIdError {
            get {
                return ResourceManager.GetString("DuplicateEventSourceIdError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The event source name &apos;{0}&apos; is duplicated in the sink &apos;{1}&apos;..
        /// </summary>
        internal static string DuplicateEventSourceNameError {
            get {
                return ResourceManager.GetString("DuplicateEventSourceNameError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate sinks..
        /// </summary>
        internal static string DuplicateSinksError {
            get {
                return ResourceManager.GetString("DuplicateSinksError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configuration element:{0}{1}.{2}.
        /// </summary>
        internal static string ElementInfoErrorMessage {
            get {
                return ResourceManager.GetString("ElementInfoErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is an ambiguity when both name and id are specified. Specify only one value..
        /// </summary>
        internal static string EventSourceAmbiguityError {
            get {
                return ResourceManager.GetString("EventSourceAmbiguityError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum length for a session name prefix is {0}..
        /// </summary>
        internal static string ExceptionSessionPrefixNameTooLong {
            get {
                return ResourceManager.GetString("ExceptionSessionPrefixNameTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not created the formatter specified in configuration element name &apos;{0}&apos;..
        /// </summary>
        internal static string FormatterElementNotResolvedError {
            get {
                return ResourceManager.GetString("FormatterElementNotResolvedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameters specified in this element does not map to an existing type member. All paramters are required in the same order of the defined type member. .
        /// </summary>
        internal static string IncompleteArgumentsError {
            get {
                return ResourceManager.GetString("IncompleteArgumentsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem, LocalService, NetworkService can control event tracing sessions. To grant a restricted user the ability to control trace sessions, add them to the Performance Log Users group..
        /// </summary>
        internal static string InsufficientPrivileges {
            get {
                return ResourceManager.GetString("InsufficientPrivileges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value does not represent a connection string.
        /// </summary>
        internal static string InvalidConnectionStringError {
            get {
                return ResourceManager.GetString("InvalidConnectionStringError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  {0}Line: &apos;{1}&apos;, Position: &apos;{2}&apos;..
        /// </summary>
        internal static string LineInfoMessage {
            get {
                return ResourceManager.GetString("LineInfoMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;ElementName&apos; value in XmlRootAttribute of type &apos;{0}&apos; is misssing, null or empty..
        /// </summary>
        internal static string MissingElementNameInXmlRootAttributeError {
            get {
                return ResourceManager.GetString("MissingElementNameInXmlRootAttributeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The EventSource &apos;name&apos; and &apos;id&apos; values are missing. Please provide either name or id..
        /// </summary>
        internal static string MissingEventSourceNameAndId {
            get {
                return ResourceManager.GetString("MissingEventSourceNameAndId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Namespace&apos; value in XmlRootAttribute of type &apos;{0}&apos; is missing, null or empty..
        /// </summary>
        internal static string MissingNamespaceInXmlRootAttributeError {
            get {
                return ResourceManager.GetString("MissingNamespaceInXmlRootAttributeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XmlRootAttribute missing in type &apos;{0}&apos; with name and namespace values..
        /// </summary>
        internal static string MissingXmlRootAttributeError {
            get {
                return ResourceManager.GetString("MissingXmlRootAttributeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No event listeners specified in configuration..
        /// </summary>
        internal static string NoEventListenersError {
            get {
                return ResourceManager.GetString("NoEventListenersError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No event sources specified in configuration for this event listener: &apos;{0}&apos;..
        /// </summary>
        internal static string NoEventSourcesError {
            get {
                return ResourceManager.GetString("NoEventSourcesError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  in namespace &apos;{0}&apos;.
        /// </summary>
        internal static string RemoveNamespaceFromErrrMessage {
            get {
                return ResourceManager.GetString("RemoveNamespaceFromErrrMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A sink was added from configuration changes..
        /// </summary>
        internal static string SinkAddedFromReconfiguration {
            get {
                return ResourceManager.GetString("SinkAddedFromReconfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The sink element definition with name &apos;{0}&apos; could not be resolved by an existing SinkElement implementation..
        /// </summary>
        internal static string SinkElementNotResolvedError {
            get {
                return ResourceManager.GetString("SinkElementNotResolvedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A sink was removed from configuration changes..
        /// </summary>
        internal static string SinkRemovedFromReconfiguration {
            get {
                return ResourceManager.GetString("SinkRemovedFromReconfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A sink was updated from configuration changes..
        /// </summary>
        internal static string SinkUpdatedFromReconfiguration {
            get {
                return ResourceManager.GetString("SinkUpdatedFromReconfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The execution time was longer than {0} milliseconds..
        /// </summary>
        internal static string TaskTimeoutError {
            get {
                return ResourceManager.GetString("TaskTimeoutError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more errors occurred when loading the TraceEventService configuration file..
        /// </summary>
        internal static string TraceEventServiceConfigurationExceptionDefaultMessage {
            get {
                return ResourceManager.GetString("TraceEventServiceConfigurationExceptionDefaultMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configuration file: {0}.
        /// </summary>
        internal static string TraceEventServiceConfigurationFileFormat {
            get {
                return ResourceManager.GetString("TraceEventServiceConfigurationFileFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}{1}Line number: {2}, Line position: {3}.
        /// </summary>
        internal static string XmlSchemaValidationExceptionFormat {
            get {
                return ResourceManager.GetString("XmlSchemaValidationExceptionFormat", resourceCulture);
            }
        }
    }
}
