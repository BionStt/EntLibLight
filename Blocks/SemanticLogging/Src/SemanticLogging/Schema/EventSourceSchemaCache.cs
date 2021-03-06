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

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using EntLibExtensions.SemanticLogging.Utility;

namespace EntLibExtensions.SemanticLogging.Schema
{
    using Microsoft.Diagnostics.Tracing;

    /// <summary>
    /// Used for caching <see cref="EventSchema"/>.
    /// </summary>
    public class EventSourceSchemaCache
    {
        private readonly ConcurrentDictionary<Guid, IReadOnlyDictionary<int, EventSchema>> schemas = new ConcurrentDictionary<Guid, IReadOnlyDictionary<int, EventSchema>>();
        private readonly EventSourceSchemaReader schemaReader = new EventSourceSchemaReader();

        static EventSourceSchemaCache()
        {
            Instance = new EventSourceSchemaCache();
        }

        /// <summary>
        /// Gets the singleton instance of <see cref="EventSourceSchemaCache"/>.
        /// </summary>
        /// <value>The instance of EventSourceSchemaCache.</value>
        public static EventSourceSchemaCache Instance { get; private set; }

        /// <summary>
        /// Gets the <see cref="EventSchema"/> for the specified eventId and eventSource.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        /// <param name="eventSource">The event source.</param>
        /// <returns>The EventSchema.</returns>
        public EventSchema GetSchema(int eventId, EventSource eventSource)
        {
            Guard.ArgumentNotNull(eventSource, "eventSource");

            IReadOnlyDictionary<int, EventSchema> events;

            if (!this.schemas.TryGetValue(eventSource.Guid, out events))
            {
                events = new ReadOnlyDictionary<int, EventSchema>(this.schemaReader.GetSchema(eventSource));
                this.schemas[eventSource.Guid] = events;
            }

            return events[eventId];
        }
    }
}
