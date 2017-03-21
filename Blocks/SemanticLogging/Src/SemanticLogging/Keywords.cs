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



namespace EntLibExtensions.SemanticLogging
{
    using Microsoft.Diagnostics.Tracing;

    /// <summary>
    /// EventKeywords additional constants for <see cref="System.Diagnostics.Tracing.EventKeywords"/>.
    /// </summary>
    public static class Keywords
    {
        /// <summary>
        /// Keyword flags to enable all the events. 
        /// </summary>
        public const EventKeywords All = EventKeywords.All;
    }
}
