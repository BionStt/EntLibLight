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

using EntLibExtensions.SemanticLogging.Formatters;
using System;
using System.Collections.Generic;
using System.IO;

namespace EntLibExtensions.SemanticLogging.Tests.TestObjects
{
    public class MockFormatter : IEventTextFormatter
    {
        public List<EventEntry> WriteEventCalls = new List<EventEntry>();
        public Action<MockFormatter> BeforeWriteEventAction { get; set; }
        public Action<MockFormatter> AfterWriteEventAction { get; set; }

        public void WriteEvent(EventEntry eventData, TextWriter writer)
        {
            this.WriteEventCalls.Add(eventData);

            if (BeforeWriteEventAction != null)
                BeforeWriteEventAction(this);

            if (!string.IsNullOrWhiteSpace(eventData.FormattedMessage))
                writer.Write(eventData.FormattedMessage);
            writer.Write(string.Join(",", eventData.Payload));

            if (AfterWriteEventAction != null)
                AfterWriteEventAction(this);
        }
    }
}
