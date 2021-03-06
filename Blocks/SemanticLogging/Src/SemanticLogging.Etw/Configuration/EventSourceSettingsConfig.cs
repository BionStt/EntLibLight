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


namespace EntLibExtensions.SemanticLogging.Etw.Configuration
{
    using Microsoft.Diagnostics.Tracing;

    using Microsoft.Diagnostics.Tracing.Session;

    /// <summary>
    /// Represents the event source configuration settings.
    /// </summary>
    public class EventSourceSettingsConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSourceSettingsConfig"/> class.
        /// </summary>
        /// <param name="name">The friendly event source name.</param>
        /// <param name="eventSourceId">The event source id.</param>
        /// <param name="level">The level.</param>
        /// <param name="matchAnyKeyword">The match any keyword.</param>
        /// <exception cref="ConfigurationException">A validation exception.</exception>
        public EventSourceSettingsConfig(string name = null, Guid? eventSourceId = null, EventLevel level = EventLevel.LogAlways, EventKeywords matchAnyKeyword = EventKeywords.All)
        {
            // If no Id, Name should not be optional so we may derive an Id from it.
            if (!eventSourceId.HasValue || eventSourceId == Guid.Empty)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ConfigurationException(Properties.Resources.MissingEventSourceNameAndId);
                }

                eventSourceId = TraceEventProviders.GetEventSourceGuidFromName(name);
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                // throw and both name & Id specified
                throw new ConfigurationException(Properties.Resources.EventSourceAmbiguityError);
            }

            this.EventSourceId = eventSourceId.Value;
            this.Name = name ?? eventSourceId.ToString(); // Set a not null value for later use
            this.Level = level;
            this.MatchAnyKeyword = matchAnyKeyword;
        }

        /// <summary>
        /// Gets or sets the event source ID to monitor traced events.
        /// </summary>
        /// <value>
        /// The name identifier.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the event source ID to monitor traced events.
        /// </summary>
        /// <value>
        /// The event source id.
        /// </value>
        public Guid EventSourceId { get; internal set; }

        /// <summary>
        /// Gets or sets the <see cref="EventLevel" />.
        /// </summary>
        /// <value>
        /// The event level.
        /// </value>
        public EventLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the keyword flags necessary to enable the events.
        /// </summary>
        /// <value>
        /// The <see cref="EventKeywords"/>.
        /// </value>
        public EventKeywords MatchAnyKeyword { get; set; }
    }
}
