﻿#region license
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

using System.Collections.Concurrent;

using EntLibExtensions.SemanticLogging.Schema;

namespace EntLibExtensions.SemanticLogging.Tests.TestObjects
{
    using Microsoft.Diagnostics.Tracing;

    public class MockEventListener : EventListener
    {
        public ConcurrentBag<EventEntry> WrittenEntries = new ConcurrentBag<EventEntry>();

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            WrittenEntries.Add(EventEntry.Create(eventData, EventSourceSchemaCache.Instance.GetSchema(eventData.EventId, eventData.EventSource)));
        }
    }
}
