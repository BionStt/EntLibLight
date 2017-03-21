#region license
// ==============================================================================
// Microsoft patterns & practices Enterprise Library
// Semantic Logging Application Block
// ==============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
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
using System.Linq;

namespace EntLibExtensions.SemanticLogging.Tests.Etw
{
    [TestClass]
    public class given_sinkSettings
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void when_creating_instance_with_null_name()
        {
            new SinkSettings(null, new InMemoryEventListener(), Enumerable.Empty<EventSourceSettingsConfig>());
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException))]
        public void when_creating_instance_with_null_sink()
        {
            new SinkSettings("name", sink: null, eventSources: Enumerable.Empty<EventSourceSettingsConfig>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void when_creating_instance_with_null_sources()
        {
            new SinkSettings("name", new InMemoryEventListener(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void when_creating_instance_with_max_name_length()
        {
            new SinkSettings(new string('a', 201), new InMemoryEventListener(), Enumerable.Empty<EventSourceSettingsConfig>());
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException))]
        public void when_creating_instance_with_empty_sources()
        {
            new SinkSettings("test", new InMemoryEventListener(), Enumerable.Empty<EventSourceSettingsConfig>());
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException))]
        public void when_creating_instance_with_duplicate_sources_by_name()
        {
            var sources = new List<EventSourceSettingsConfig>() { new EventSourceSettingsConfig("test"), new EventSourceSettingsConfig("test") };
            new SinkSettings("test", new InMemoryEventListener(), sources);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException))]
        public void when_creating_instance_with_duplicate_sources_by_id()
        {
            var sources = new List<EventSourceSettingsConfig>() { new EventSourceSettingsConfig(eventSourceId: MyCompanyEventSource.Log.Guid), new EventSourceSettingsConfig(eventSourceId: MyCompanyEventSource.Log.Guid) };
            new SinkSettings("test", new InMemoryEventListener(), sources);
        }

        [TestMethod]
        public void when_creating_instance_with_default_values()
        {
            var sources = new List<EventSourceSettingsConfig>() { new EventSourceSettingsConfig(MyCompanyEventSource.Log.Name) };
            var sink = new InMemoryEventListener();
            var sut = new SinkSettings("test", sink, sources);

            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual(sink, sut.Sink);
            Assert.AreEqual(1, sut.EventSources.Count());
        }
    }
}
