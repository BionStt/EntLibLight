namespace EntLibExtensions.Infrastructure
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The utility to launch processes
    /// </summary>
    public static class ProcessUtility
    {
        /// <summary>
        /// The run process.
        /// </summary>
        /// <param name="processStartInfo">
        /// The process start info.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// The <see cref="int"/> exit code or -1 in case of timeout.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Argument Exception
        /// </exception>
        public static int RunProcess(ProcessStartInfo processStartInfo, out string output, TimeSpan? timeout = null)
        {
            if (processStartInfo == null)
            {
                throw new ArgumentNullException(nameof(processStartInfo));
            }
            output = null;
            timeout = timeout ?? TimeSpan.FromHours(1);

            int milliseconds = (int)timeout.Value.TotalMilliseconds;
            string token = InfraEventSource.Log.ExternalProcessRun(processStartInfo, milliseconds);
            Process process;

            try
            {
                process = Process.Start(processStartInfo);
                if (process == null)
                {
                    throw new InvalidOperationException("Failed to start process");
                }
            }
            catch (Exception e)
            {
                InfraEventSource.Log.ExternalProcessFailedToStart(
                    processStartInfo.FileName,
                    token,
                    e.Message,
                    e.ToString());
                throw;
            }

            bool finished = process.WaitForExit(milliseconds);
            string standardOutput = process.StandardOutput.ReadToEnd();
            string standardError = process.StandardError.ReadToEnd();
            if (!finished)
            {
                output = standardError;
                InfraEventSource.Log.ExternalProcessTimeout(
                    processStartInfo.FileName,
                    token,
                    output);
                return -1;
            }

            if (process.ExitCode != 0)
            {
                output = standardError;
                InfraEventSource.Log.ExternalProcessEndWithError(
                    processStartInfo.FileName,
                    token,
                    process.ExitCode,
                    output);
            }
            else
            {
                output = standardOutput;
                InfraEventSource.Log.ExternalProcessEnd(
                    processStartInfo.FileName,
                    token,
                    output);
            }

            return process.ExitCode;
        }

        /// <summary>
        /// The run process.
        /// </summary>
        /// <param name="procName">
        /// The process name or file path.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Argument Exception
        /// </exception>
        public static int RunProcess(
            string procName,
            out string output,
            string arguments = null,
            TimeSpan? timeout = null)
        {
            if (procName == null)
            {
                throw new ArgumentNullException(nameof(procName));
            }

            if (string.IsNullOrWhiteSpace(procName))
            {
                throw new ArgumentException(nameof(procName));
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo(procName, arguments)
                                                    {
                                                        CreateNoWindow = true,
                                                        RedirectStandardError = true,
                                                        RedirectStandardOutput = true,
                                                        UseShellExecute = false
                                                    };

            return RunProcess(processStartInfo, out output, timeout);
        }
    }
}