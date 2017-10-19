namespace EntLibExtensions.Infrastructure
{
    using System;
    using System.Security.Principal;

    using Microsoft.Diagnostics.Tracing;

    /// <summary>
    /// The infra event source.
    /// </summary>
    public sealed class InfraEventSource : EventSource
    {
        private static string name = "EntLibExtensions-Infrastructure";

        /// <summary>
        /// The initialized.
        /// </summary>
        private static bool initialized;

        /// <summary>
        /// Prevents a default instance of the <see cref="InfraEventSource"/> class from being created.
        /// </summary>
        private InfraEventSource():base(name)
        {
            initialized = true;
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        public static InfraEventSource Log { get; } = new InfraEventSource();

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public static void Initialize(string name)
        {
            if (initialized)
            {
                throw new InvalidOperationException(
                    "Event source already used. Try to call Initialize method at the very beginning of application lifecycle");
            }

            InfraEventSource.name = name;
        }

        /// <summary>
        /// The app start.
        /// </summary>
        /// <param name="appName">
        /// The app Name.
        /// </param>
        /// <param name="interactive">
        /// The interactive.
        /// </param>
        /// <param name="machineName">
        /// The machine name.
        /// </param>
        /// <param name="userName">
        /// The user name.
        /// </param>
        [Event(1, Message = "{0} application started.", Level = EventLevel.Informational, Keywords = Keywords.Application)]
        public void AppStart(string appName, bool interactive, string machineName, string userName)
        {
            this.WriteEvent(1, appName, interactive, machineName, userName);
        }

        /// <summary>
        /// The app start default.
        /// </summary>
        [NonEvent]
        public void AppStartDefault()
        {
            this.AppStart(
                AppDomain.CurrentDomain.FriendlyName,
                Environment.UserInteractive,
                Environment.MachineName,
                WindowsIdentity.GetCurrent().Name);
        }

        /// <summary>
        /// The app end
        /// </summary>
        /// <param name="appName">
        /// The app Name.
        /// </param>
        /// <param name="exitCode">
        /// The exit Code.
        /// </param>
        [Event(2, Message = "{0} application finished. Exit Code {1}.", Level = EventLevel.Informational, Keywords = Keywords.Application)]
        public void AppEnd(string appName, int exitCode)
        {
            this.WriteEvent(2, appName, exitCode);
        }

        /// <summary>
        /// The app end default.
        /// </summary>
        [NonEvent]
        public void AppEndDefault()
        {
            this.AppEnd(AppDomain.CurrentDomain.FriendlyName, Environment.ExitCode);
        }

        /// <summary>
        /// The app critical failure.
        /// </summary>
        /// <param name="appName">
        /// The app name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        [Event(3, Message = "{0} critical Failure: {0}. See event payload for details", Level = EventLevel.Critical, Keywords = Keywords.Application)]
        public void AppCriticalFailure(string appName, string message, string exception)
        {
            this.WriteEvent(3, appName, message, exception);
        }

        /// <summary>
        /// The app critical failure.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        [NonEvent]
        public void AppCriticalFailure(Exception exception)
        {
            this.AppCriticalFailure(AppDomain.CurrentDomain.FriendlyName, exception.Message, exception.ToString());
        }

        /// <summary>
        /// The key words.
        /// </summary>
        public class Keywords
        {
            /// <summary>
            /// The application.
            /// </summary>
            public const EventKeywords Application = (EventKeywords)1;

            /// <summary>
            /// The service.
            /// </summary>
            public const EventKeywords WinService = (EventKeywords)2;

            /// <summary>
            /// The host.
            /// </summary>
            public const EventKeywords WorkersHost = (EventKeywords)4;

            /// <summary>
            /// The action.
            /// </summary>
            public const EventKeywords WorkerAction = (EventKeywords)8;            
        }

        /// <summary>
        /// The tasks.
        /// </summary>
        public class Tasks
        {
            /// <summary>
            /// The run action.
            /// </summary>
            public const EventTask WorkerAction = (EventTask)1;
        }
    }
}