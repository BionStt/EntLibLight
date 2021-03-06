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

using EntLibExtensions.SemanticLogging.Formatters;
using EntLibExtensions.SemanticLogging.Sinks;
using EntLibExtensions.SemanticLogging.Utility;

namespace EntLibExtensions.SemanticLogging
{
    using Microsoft.Diagnostics.Tracing;

    /// <summary>
    /// Factories and helpers for using the <see cref="ConsoleSink"/>.
    /// </summary>
    public static class ConsoleLog
    {
        /// <summary>
        /// Subscribes to an <see cref="IObservable{EventEntry}"/> using a <see cref="ConsoleSink"/>.
        /// </summary>
        /// <param name="eventStream">The event stream. Typically this is an instance of <see cref="ObservableEventListener"/>.</param>
        /// <param name="formatter">The formatter.</param>
        /// <param name="colorMapper">The color mapper instance.</param>
        /// <returns>A subscription to the sink that can be disposed to unsubscribe the sink, or to get access to the sink instance.</returns>
        public static SinkSubscription<ConsoleSink> LogToConsole(this IObservable<EventEntry> eventStream, IEventTextFormatter formatter = null, IConsoleColorMapper colorMapper = null)
        {
            var sink = new ConsoleSink();

            formatter = formatter ?? new EventTextFormatter();
            colorMapper = colorMapper ?? new DefaultConsoleColorMapper();

            var subscription = eventStream.SubscribeWithFormatterAndColor(formatter ?? new EventTextFormatter(), colorMapper, sink);

            return new SinkSubscription<ConsoleSink>(subscription, sink);
        }

        /// <summary>
        /// Creates an event listener that logs using a <see cref="ConsoleSink"/>.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        /// <param name="colorMapper">The color mapper instance.</param>
        /// <returns>An event listener that uses <see cref="ConsoleSink"/> to display events.</returns>
        public static EventListener CreateListener(IEventTextFormatter formatter = null, IConsoleColorMapper colorMapper = null)
        {
            var listener = new ObservableEventListener();
            listener.LogToConsole(formatter, colorMapper);
            return listener;
        }
    }
}
