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
using System.Diagnostics;

using EntLibExtensions.SemanticLogging.Formatters;
using EntLibExtensions.SemanticLogging.Schema;
using EntLibExtensions.SemanticLogging.Utility;

namespace EntLibExtensions.SemanticLogging.Etw.Service
{
    using Microsoft.Diagnostics.Tracing;

    internal class ServiceEventLogSink : IObserver<EventEntry>
    {
        private readonly IEventTextFormatter formatter;
        private EventLog eventLog;

        internal ServiceEventLogSink(EventLog eventLog)
        {
            this.eventLog = eventLog;
            this.formatter = new EventTextFormatter();
        }

        public void OnCompleted()
        {
            this.eventLog = null;
        }

        public void OnError(Exception error)
        {
            this.eventLog = null;
        }

        public void OnNext(EventEntry value)
        {
            var log = this.eventLog;
            if (log != null)
            {                
                log.WriteEntry(this.formatter.WriteEvent(value), this.ToEventLogEntryType(value.Schema.Level));
            }
        }

        private EventLogEntryType ToEventLogEntryType(EventLevel level)
        {
            switch (level)
            {
                case EventLevel.Critical:
                case EventLevel.Error:
                    return EventLogEntryType.Error;
                case EventLevel.Warning:
                    return EventLogEntryType.Warning;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}
