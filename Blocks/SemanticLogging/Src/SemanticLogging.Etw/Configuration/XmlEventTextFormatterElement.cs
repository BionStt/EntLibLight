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
using System.Xml.Linq;
using EntLibExtensions.SemanticLogging.Formatters;

namespace EntLibExtensions.SemanticLogging.Etw.Configuration
{
    /// <summary>
    /// Represents a configuration element that can create an instance of <see cref="XmlEventTextFormatter"/>.
    /// </summary>
    internal class XmlEventTextFormatterElement : IFormatterElement
    {
        private readonly XName formatterName = XName.Get("xmlEventTextFormatter", Constants.Namespace);

        /// <summary>
        /// Determines whether this instance [can create sink] the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can create sink] the specified element; otherwise, <c>false</c>.
        /// </returns>
        public bool CanCreateFormatter(XElement element)
        {
            return this.GetFormatterElement(element) != null;
        }

        /// <summary>
        /// Creates the <see cref="IEventTextFormatter" /> instance.
        /// </summary>
        /// <param name="element">The configuration element.</param>
        /// <returns>
        /// The formatter instance.
        /// </returns>
        public IEventTextFormatter CreateFormatter(XElement element)
        {
            var formatter = this.GetFormatterElement(element);

            EventTextFormatting formatting = (EventTextFormatting)Enum.Parse(typeof(EventTextFormatting), (string)formatter.Attribute("formatting") ?? XmlEventTextFormatter.DefaultEventTextFormatting.ToString());

            return new XmlEventTextFormatter(formatting, (string)formatter.Attribute("dateTimeFormat"));
        }

        private XElement GetFormatterElement(XElement element)
        {
            return element.Element(this.formatterName);
        }
    }
}
