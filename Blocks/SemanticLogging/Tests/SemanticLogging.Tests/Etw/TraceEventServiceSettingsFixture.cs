#region license
// ==============================================================================
// Microsoft patterns & practices Enterprise Library
// Semantic Logging Application Block
// ==============================================================================
// Copyright © Microsoft Corporation.  All rights reserved. Modifications copyright © 2017 Ihar Yakimush
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ==============================================================================
#endregion

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntLibExtensions.SemanticLogging.Etw;
using EntLibExtensions.SemanticLogging.Etw.Configuration;
using EntLibExtensions.SemanticLogging.Tests.TestSupport;

namespace EntLibExtensions.SemanticLogging.Tests.Etw
{
    [TestClass]
    public class given_traceEventServiceSettings_configuration
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void when_creating_instance_with_null_sessionName()
        {
            new TraceEventServiceSettings() { SessionNamePrefix = null };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void when_creating_instance_with_empty_sessionName()
        {
            new TraceEventServiceSettings() { SessionNamePrefix = string.Empty };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void when_creating_instance_with_max_sessionName_length()
        {
            new TraceEventServiceSettings() { SessionNamePrefix = new string('a', 201) };
        }

        [TestMethod]
        public void when_creating_instance_with_default_values()
        {
            var sut = new TraceEventServiceSettings();

            Assert.IsTrue(sut.SessionNamePrefix.StartsWith(Constants.DefaultSessionNamePrefix));
        }
    }
}
