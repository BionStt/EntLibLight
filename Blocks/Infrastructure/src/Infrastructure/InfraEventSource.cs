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
        [Event(4, Message = "Run external process {0}. Token {1}", Level = EventLevel.Informational, Keywords = Keywords.Application)]
        public void ExternalProcessRun(string fileName, string token, int milliseconds, string userName, bool createNoWindow, bool loadUserProfile, bool errorDialog)
        {
            this.WriteEvent(4, fileName, token, milliseconds, userName, createNoWindow, loadUserProfile, errorDialog);
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
        [Event(5, Message = "External process failed {0}. Token {1} Message {2}", Level = EventLevel.Error, Keywords = Keywords.Application)]
        public void ExternalProcessFailedToStart(string fileName, string token, string errorMessage, string exception)
        {
            this.WriteEvent(5, fileName, token, errorMessage, exception);
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
        [Event(6, Message = "External process timeout {0}. Token {1}", Level = EventLevel.Warning, Keywords = Keywords.Application)]
        public void ExternalProcessTimeout(string fileName, string token, string output)
        {
            this.WriteEvent(6, fileName, token, output);
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
        [Event(7, Message = "External process end {0}. Token {1}. Exit code {2}", Level = EventLevel.Warning, Keywords = Keywords.Application)]
        public void ExternalProcessEndWithError(string fileName, string token, int code, string output)
        {
            this.WriteEvent(7, fileName, token, code, output);
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
        [Event(8, Message = "External process end {0}. Token {1}. Exit code {2}", Level = EventLevel.Informational, Keywords = Keywords.Application)]
        public void ExternalProcessEnd(string fileName, string token, string output)
        {
            this.WriteEvent(8, fileName, token, output);
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