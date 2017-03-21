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

using EntLibExtensions.SemanticLogging.Etw.Configuration;
using EntLibExtensions.SemanticLogging.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace EntLibExtensions.SemanticLogging.Tests.Etw
{
    using Microsoft.Diagnostics.Tracing;

    [TestClass]
    public class given_eventSourceSettings
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationException))]
        public void when_creating_instance_with_no_values()
        {
            new EventSourceSettingsConfig();
        }

        [TestMethod]
        public void when_creating_instance_with_name_only()
        {
            var sut = new EventSourceSettingsConfig(MyCompanyEventSource.Log.Name);

            Assert.AreEqual(MyCompanyEventSource.Log.Name, sut.Name);
            Assert.AreEqual(MyCompanyEventSource.Log.Guid, sut.EventSourceId);
            Assert.AreEqual(EventLevel.LogAlways, sut.Level);
            Assert.AreEqual(Keywords.All, sut.MatchAnyKeyword);
        }

        [TestMethod]
        public void when_creating_instance_with_id_only()
        {
            var sut = new EventSourceSettingsConfig(eventSourceId: MyCompanyEventSource.Log.Guid);

            Assert.AreEqual(MyCompanyEventSource.Log.Guid.ToString(), sut.Name);
            Assert.AreEqual(MyCompanyEventSource.Log.Guid, sut.EventSourceId);
            Assert.AreEqual(EventLevel.LogAlways, sut.Level);
            Assert.AreEqual(Keywords.All, sut.MatchAnyKeyword);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException))]
        public void when_creating_instance_with_both_name_and_id()
        {
            new EventSourceSettingsConfig(MyCompanyEventSource.Log.Name, MyCompanyEventSource.Log.Guid);
        }
    }
}
