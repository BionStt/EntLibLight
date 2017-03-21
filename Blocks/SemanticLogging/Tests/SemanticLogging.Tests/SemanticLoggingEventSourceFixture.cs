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


using EntLibExtensions.SemanticLogging.Tests.TestObjects;
using EntLibExtensions.SemanticLogging.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntLibExtensions.SemanticLogging.Tests
{
    using Microsoft.Diagnostics.Tracing;

    [TestClass]
    public class SemanticLoggingEventSourceFixture
    {
        [TestMethod]
        public void ShouldValidateEventSource()
        {
            EventSourceAnalyzer.InspectAll(SemanticLoggingEventSource.Log);
        }

        [TestMethod]
        public void ShouldWriteWithNoFiltering()
        {
            using (var listener = new InMemoryEventListener())
            {
                listener.EnableEvents(SemanticLoggingEventSource.Log, EventLevel.LogAlways, Keywords.All);

                SemanticLoggingEventSource.Log.DatabaseSinkPublishEventsFailed("test");

                listener.DisableEvents(SemanticLoggingEventSource.Log);

                StringAssert.Contains(listener.ToString(), "EventId : 101");
                StringAssert.Contains(listener.ToString(), "Level : Error");
                StringAssert.Contains(listener.ToString(), "Payload : [message : test]");
            }
        }

        [TestMethod]
        public void ShouldWriteByErrorLevel()
        {
            using (var listener = new InMemoryEventListener())
            {
                listener.EnableEvents(SemanticLoggingEventSource.Log, EventLevel.Error, Keywords.All);

                SemanticLoggingEventSource.Log.ConsoleSinkWriteFailed("test");

                listener.DisableEvents(SemanticLoggingEventSource.Log);

                StringAssert.Contains(listener.ToString(), "EventId : 200");
                StringAssert.Contains(listener.ToString(), "Level : Critical");
                StringAssert.Contains(listener.ToString(), "Payload : [message : test]");
            }
        }

        [TestMethod]
        public void ShouldWriteByEventKeywords()
        {
            using (var listener = new InMemoryEventListener())
            {
                listener.EnableEvents(SemanticLoggingEventSource.Log, EventLevel.LogAlways, SemanticLoggingEventSource.Keywords.Sink);

                SemanticLoggingEventSource.Log.ConsoleSinkWriteFailed("test");

                listener.DisableEvents(SemanticLoggingEventSource.Log);

                StringAssert.Contains(listener.ToString(), "EventId : 200");
                StringAssert.Contains(listener.ToString(), "Level : Critical");
                StringAssert.Contains(listener.ToString(), "Payload : [message : test]");
            }
        }

        [TestMethod]
        public void ShouldFilterByEventKeywords()
        {
            using (var listener = new InMemoryEventListener())
            {
                listener.EnableEvents(SemanticLoggingEventSource.Log, EventLevel.LogAlways);

                SemanticLoggingEventSource.Log.ConsoleSinkWriteFailed("test");

                listener.DisableEvents(SemanticLoggingEventSource.Log);

                Assert.AreEqual(string.Empty, listener.ToString());
            }
        }
    }
}
