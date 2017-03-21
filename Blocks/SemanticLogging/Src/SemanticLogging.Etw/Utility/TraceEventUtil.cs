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

using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;

using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;

namespace Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Etw.Utility
{
    using Microsoft.Diagnostics.Tracing;
    using Microsoft.Diagnostics.Tracing.Session;

    internal static class TraceEventUtil
    {
        internal const TraceEventID ManifestEventID = (TraceEventID)0xFFFE;

        internal static TraceEventSession CreateSession(string sessionName)
        {
            if (TraceEventSession.GetActiveSessionNames().Contains(sessionName, StringComparer.OrdinalIgnoreCase))
            {
                // Notify of session removal
                SemanticLoggingEventSource.Log.TraceEventServiceSessionRemoved(sessionName);

                // Remove existing session
                new TraceEventSession(sessionName) { StopOnDispose = true }.Dispose();
            }

            return new TraceEventSession(sessionName, null) { StopOnDispose = true };
        }

        internal static void EnableProvider(TraceEventSession session, Guid providerId, EventLevel level, EventKeywords matchAnyKeyword)
        {        
            session.EnableProvider(
                providerId,
                (TraceEventLevel)level,
                (ulong)matchAnyKeyword);
        }
    }
}
