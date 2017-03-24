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

namespace ExceptionHandling
{
    using System;
    using System.Collections.Generic;    
    using System.Linq;

    using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

    /// <summary>
    /// 
    /// </summary>
    public static class ExceptionPolicyDefinitionFactory
    {
        /// <summary>
        /// Create <see cref="ExceptionPolicyDefinition"/> to implement exception shielding for component. 
        /// 1. rethrow all exceptions derived from component base exception <typeparamref name="TBaseException"/>
        /// 2. rethrow <see cref="OperationCanceledException"/>
        /// 3. wrap generic exceptions to component specific exception <typeparamref name="TBaseException"/>
        /// </summary>
        /// <param name="policyDefinitionName">Policy definition name</param>
        /// <param name="wrapExceptionMessage">string resolver to be used in case of wrapping generic exception to component specific exception</param>
        /// <param name="wrapExceptionBeforeHandlers">additional handlers <see cref="IExceptionHandler"/> which will be executed before wrapping generic exception to component specific exception</param>
        /// <param name="additionalPolicyEntries">additional <see cref="ExceptionPolicyEntry"/> which will be added to policy definition before default ones</param>
        /// <typeparam name="TBaseException">Type of base class for component specific exceptions</typeparam>
        /// <returns>Policy definition <see cref="ExceptionPolicyDefinition"/></returns>
        public static ExceptionPolicyDefinition CreateShieldingForComponent<TBaseException>(
            string policyDefinitionName = null,
            IStringResolver wrapExceptionMessage = null,
            IEnumerable<IExceptionHandler> wrapExceptionBeforeHandlers = null,
            IEnumerable<ExceptionPolicyEntry> additionalPolicyEntries = null) where TBaseException : Exception
        {
            if (policyDefinitionName == null)
            {
                policyDefinitionName = "ShieldingFor" + typeof(TBaseException).FullName;
            }

            List<IExceptionHandler> handlers = wrapExceptionBeforeHandlers?.ToList() ?? new List<IExceptionHandler>();

            WrapHandler wrapHandler = wrapExceptionMessage == null
                                          ? new WrapHandler(
                                                "Unhandled exception. See inner for details",
                                                typeof(TBaseException))
                                          : new WrapHandler(wrapExceptionMessage, typeof(TBaseException));

            handlers.Add(wrapHandler);

            List<ExceptionPolicyEntry> policyEntries = additionalPolicyEntries?.ToList()
                                                       ?? new List<ExceptionPolicyEntry>();

            policyEntries.Add(
                new ExceptionPolicyEntry(
                    typeof(TBaseException),
                    PostHandlingAction.NotifyRethrow,
                    Enumerable.Empty<IExceptionHandler>()));

            policyEntries.Add(
                new ExceptionPolicyEntry(
                    typeof(OperationCanceledException),
                    PostHandlingAction.NotifyRethrow,
                    Enumerable.Empty<IExceptionHandler>()));

            policyEntries.Add(
                new ExceptionPolicyEntry(typeof(Exception), PostHandlingAction.ThrowNewException, handlers));

            ExceptionPolicyDefinition result = new ExceptionPolicyDefinition(policyDefinitionName, policyEntries);

            return result;
        }

        /// <summary>
        /// Create <see cref="ExceptionPolicyDefinition"/> to implement exception shielding for component. 
        /// 1. rethrow all exceptions derived from component base exception <typeparamref name="TBaseException"/>
        /// 2. rethrow <see cref="OperationCanceledException"/>
        /// 3. wrap generic exceptions to component specific exception <typeparamref name="TBaseException"/>
        /// </summary>
        /// <param name="policyDefinitionName">Policy definition name</param>
        /// <param name="wrapExceptionMessage">custom message to be used in case of wrapping generic exception to component specific exception</param>
        /// <param name="wrapExceptionBeforeHandlers">additional handlers <see cref="IExceptionHandler"/> which will be executed before wrapping generic exception to component specific exception</param>
        /// <param name="additionalPolicyEntries">additional <see cref="ExceptionPolicyEntry"/> which will be added to policy definition before default ones</param>
        /// <typeparam name="TBaseException">Type of base class for component specific exceptions</typeparam>
        /// <returns>Policy definition <see cref="ExceptionPolicyDefinition"/></returns>
        public static ExceptionPolicyDefinition CreateShieldingForComponent<TBaseException>(
            string policyDefinitionName = null,
            string wrapExceptionMessage = null,
            IEnumerable<IExceptionHandler> wrapExceptionBeforeHandlers = null,
            IEnumerable<ExceptionPolicyEntry> additionalPolicyEntries = null) where TBaseException : Exception
        {
            return CreateShieldingForComponent<TBaseException>(
                policyDefinitionName,
                wrapExceptionMessage == null ? null : new ConstantStringResolver(wrapExceptionMessage),
                wrapExceptionBeforeHandlers,
                additionalPolicyEntries);
        }
    }
}