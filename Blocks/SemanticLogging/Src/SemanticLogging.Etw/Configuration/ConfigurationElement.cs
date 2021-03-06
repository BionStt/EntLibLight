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

using System.Collections.Generic;

namespace EntLibExtensions.SemanticLogging.Etw.Configuration
{
    internal class ConfigurationElement
    {
        internal TraceEventServiceElement TraceEventService { get; set; }

        internal IEnumerable<SinkConfigurationElement> SinkConfigurationElements { get; set; }
    }
}
