#region license
// ==============================================================================
// Microsoft patterns & practices Enterprise Library
// Exception Handling Application Block Extensions
// ==============================================================================
// Copyright © Ihar Yakimush
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ==============================================================================
#endregion

namespace EntLibExtensions.ExceptionHandling
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

    /// <summary>
    /// Extensions for <see cref="ExceptionManager"/> to support exception handling in async operations
    /// </summary>
    public static class ExceptionManagerExtensions
    {
        /// <summary>
        /// The process async operation which return a value with exception handling.
        /// </summary>
        /// <param name="exceptionManager">
        /// The exception manager.
        /// </param>
        /// <param name="policyName">
        /// The policy name.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <typeparam name="TResult">
        /// The returning type parameter
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        /// <exception cref="Exception">
        /// The exception
        /// </exception>
        public static async Task<TResult> ProcessAsync<TResult>(this ExceptionManager exceptionManager, string policyName, Func<Task<TResult>> action, TResult defaultValue)
        {
            if (exceptionManager == null)
            {
                throw new ArgumentNullException(nameof(exceptionManager));
            }

            if (policyName == null)
            {
                throw new ArgumentNullException(nameof(policyName));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            try
            {
                return await action();
            }
            catch (Exception e)
            {
                Exception exceptionToThrow;
                if (exceptionManager.HandleException(e, policyName, out exceptionToThrow))
                {
                    if (exceptionToThrow == null)
                    {
                        throw;
                    }

                    throw exceptionToThrow;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// The process async action with exception handling.
        /// </summary>
        /// <param name="exceptionManager">
        /// The exception manager.
        /// </param>
        /// <param name="policyName">
        /// The policy name.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public static async Task ProcessAsync(this ExceptionManager exceptionManager, string policyName, Func<Task> action)
        {
            if (exceptionManager == null)
            {
                throw new ArgumentNullException(nameof(exceptionManager));
            }

            if (policyName == null)
            {
                throw new ArgumentNullException(nameof(policyName));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            try
            {
                await action();
            }
            catch (Exception e)
            {
                Exception exceptionToThrow;
                if (exceptionManager.HandleException(e, policyName, out exceptionToThrow))
                {
                    if (exceptionToThrow == null)
                    {
                        throw;
                    }

                    throw exceptionToThrow;
                }
            }
        }
    }
}
