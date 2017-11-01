namespace EntLibExtensions.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Security.Principal;
    using System.Threading;

    using Microsoft.Diagnostics.Tracing;

    /// <summary>
    /// The infra event source.
    /// </summary>
    public sealed class InfraEventSource : EventSource
    {
        /// <summary>
        /// The log lazy.
        /// </summary>
        private static readonly Lazy<InfraEventSource> LogLazy =
            new Lazy<InfraEventSource>(() => new InfraEventSource(), true);

        /// <summary>
        /// The name.
        /// </summary>
        private static string name = "EntLibExtensions-Infrastructure";
        
        /// <summary>
        /// Prevents a default instance of the <see cref="InfraEventSource"/> class from being created.
        /// </summary>
        private InfraEventSource() : base(name)
        {
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        public static InfraEventSource Log
        {
            get
            {
                return LogLazy.Value;
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="sourceName">
        /// The name.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Invalid Operation Exception
        /// </exception>
        public static void Initialize(string sourceName)
        {
            if (LogLazy.IsValueCreated)
            {
                throw new InvalidOperationException(
                    "Event source already used. Try to call Initialize method at the very beginning of application lifecycle");
            }

            InfraEventSource.name = sourceName;
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
        /// The external process run.
        /// </summary>
        /// <param name="processStartInfo">
        /// The process start info.
        /// </param>
        /// <param name="milliseconds">
        /// Timeout for execution milliseconds
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [NonEvent]
        public string ExternalProcessRun(ProcessStartInfo processStartInfo, int milliseconds)
        {
            Guid tokenGuid = Guid.NewGuid();
            string token = tokenGuid.ToString("N").Substring(0, 8);
            this.ExternalProcessRun(
                processStartInfo.FileName,
                token,
                milliseconds,
                processStartInfo.UserName,
                processStartInfo.CreateNoWindow,
                processStartInfo.LoadUserProfile,
                processStartInfo.ErrorDialog);
            return token;
        }

        /// <summary>
        /// The external process run.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="milliseconds">
        /// The milliseconds.
        /// </param>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="createNoWindow">
        /// The create no window.
        /// </param>
        /// <param name="loadUserProfile">
        /// The load user profile.
        /// </param>
        /// <param name="errorDialog">
        /// The error dialog.
        /// </param>
        [Event(1001, Message = "Run external process {0}. Token {1}", Level = EventLevel.Informational, Keywords = Keywords.ExternalProcess)]
        public void ExternalProcessRun(string fileName, string token, int milliseconds, string userName, bool createNoWindow, bool loadUserProfile, bool errorDialog)
        {
            this.WriteEvent(1001, fileName, token, milliseconds, userName, createNoWindow, loadUserProfile, errorDialog);
        }

        /// <summary>
        /// The external process failed to start.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        [Event(1002, Message = "External process failed {0}. Token {1} Message {2}", Level = EventLevel.Error, Keywords = Keywords.ExternalProcess)]
        public void ExternalProcessFailedToStart(string fileName, string token, string errorMessage, string exception)
        {
            this.WriteEvent(1002, fileName, token, errorMessage, exception);
        }

        /// <summary>
        /// The external process timeout.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        [Event(1003, Message = "External process timeout {0}. Token {1}", Level = EventLevel.Warning, Keywords = Keywords.ExternalProcess)]
        public void ExternalProcessTimeout(string fileName, string token, string output)
        {
            this.WriteEvent(1003, fileName, token, output);
        }

        /// <summary>
        /// The external process end with error.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        [Event(1004, Message = "External process end {0}. Token {1}. Exit code {2}", Level = EventLevel.Warning, Keywords = Keywords.ExternalProcess)]
        public void ExternalProcessEndWithError(string fileName, string token, int code, string output)
        {
            this.WriteEvent(1004, fileName, token, code, output);
        }

        /// <summary>
        /// The external process end.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        [Event(1005, Message = "External process end {0}. Token {1}. Exit code {2}", Level = EventLevel.Informational, Keywords = Keywords.ExternalProcess)]
        public void ExternalProcessEnd(string fileName, string token, string output)
        {
            this.WriteEvent(1005, fileName, token, output);
        }

        /// <summary>
        /// The host start.
        /// </summary>
        /// <param name="currentDomain">
        /// The current Domain.
        /// </param>
        [Event(2001, Message = "{0} Worker host: Start", Level = EventLevel.Informational, Channel = EventChannel.Operational, Keywords = Keywords.WorkersHost)]
        public void HostStart(string currentDomain)
        {
            this.WriteEvent(2001, currentDomain);
        }

        /// <summary>
        /// The host stop.
        /// </summary>
        /// <param name="currentDomain">
        /// The current Domain.
        /// </param>
        [Event(2002, Message = "{0} Worker host: Stop", Level = EventLevel.Informational, Channel = EventChannel.Operational, Keywords = Keywords.WorkersHost)]
        public void HostStop(string currentDomain)
        {
            this.WriteEvent(2002, currentDomain);
        }

        /// <summary>
        /// The host shutdown.
        /// </summary>
        [Event(2003, Message = "Worker host: Shutdown", Level = EventLevel.Informational, Channel = EventChannel.Operational, Keywords = Keywords.WorkersHost)]
        public void HostShutdown()
        {
            this.WriteEvent(2003);
        }

        /// <summary>
        /// The host pause.
        /// </summary>
        [Event(2004, Message = "Worker host: Pause", Level = EventLevel.Informational, Channel = EventChannel.Operational, Keywords = Keywords.WorkersHost)]
        public void HostPause()
        {
            this.WriteEvent(2004);
        }

        /// <summary>
        /// The host resume.
        /// </summary>
        [Event(2005, Message = "Worker host: Resume", Level = EventLevel.Informational, Channel = EventChannel.Operational, Keywords = Keywords.WorkersHost)]
        public void HostResume()
        {
            this.WriteEvent(2005);
        }

        /// <summary>
        /// The action delay.
        /// </summary>
        /// <param name="type">
        /// The delay type.
        /// </param>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        [Event(2106, Message = "The {1} delay on {0}: {2}", Level = EventLevel.Informational, Keywords = Keywords.WorkerAction, Opcode = EventOpcode.Suspend, Task = Tasks.WorkerAction)]
        public void ActionDelay(string type, string actionType, int seconds)
        {
            this.WriteEvent(2106, type, actionType, seconds);
        }

        /// <summary>
        /// The action cancel.
        /// </summary>
        /// <param name="type">
        /// The cancel type.
        /// </param>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        [Event(2107, Message = "The {0}: canceled on {1}", Level = EventLevel.Warning, Keywords = Keywords.WorkerAction)]
        public void ActionCancel(string type, string actionType)
        {
            this.WriteEvent(2107, type, actionType);
        }

        /// <summary>
        /// The action start.
        /// </summary>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        [Event(2108, Message = "The {0} started", Level = EventLevel.Informational, Keywords = Keywords.WorkerAction, Opcode = EventOpcode.Start, Task = Tasks.WorkerAction)]
        public void ActionStart(string actionType)
        {
            this.WriteEvent(2108, actionType);
        }

        /// <summary>
        /// The action end.
        /// </summary>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        [Event(2109, Message = "The {0} started", Level = EventLevel.Informational, Keywords = Keywords.WorkerAction, Opcode = EventOpcode.Stop, Task = Tasks.WorkerAction)]
        public void ActionEnd(string actionType)
        {
            this.WriteEvent(2109, actionType);
        }

        /// <summary>
        /// The action failed.
        /// </summary>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        /// <param name="exceptionMessage">
        /// The exception message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        [Event(2110, Message = "The {0} failed: {1}", Level = EventLevel.Error, Keywords = Keywords.WorkerAction)]
        public void ActionFailed(string actionType, string exceptionMessage, string exception)
        {
            this.WriteEvent(2110, actionType, exceptionMessage, exception);
        }

        /// <summary>
        /// The action failed to reschedule.
        /// </summary>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        /// <param name="exceptionMessage">
        /// The exception message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        [Event(2111, Message = "The {0} unable to repeat task action: {1}", Level = EventLevel.Critical, Keywords = Keywords.WorkerAction | Keywords.WorkersHost)]
        public void ActionFailedToReschedule(string actionType, string exceptionMessage, string exception)
        {
            this.WriteEvent(2111, actionType, exceptionMessage, exception);
        }

        /// <summary>
        /// The action resume.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="actionType">
        /// The action type.
        /// </param>
        [Event(2112, Message = "The {1} resume from delay on {0}", Level = EventLevel.Informational, Keywords = Keywords.WorkerAction, Opcode = EventOpcode.Resume, Task = Tasks.WorkerAction)]
        public void ActionResume(string type, string actionType)
        {
            this.WriteEvent(2112, type, actionType);
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

            /// <summary>
            /// The external process.
            /// </summary>
            public const EventKeywords ExternalProcess = (EventKeywords)16;            
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