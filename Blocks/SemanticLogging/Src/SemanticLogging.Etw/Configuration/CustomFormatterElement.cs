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

using System.Xml.Linq;
using EntLibExtensions.SemanticLogging.Etw.Utility;
using EntLibExtensions.SemanticLogging.Formatters;

namespace EntLibExtensions.SemanticLogging.Etw.Configuration
{
    internal class CustomFormatterElement : IFormatterElement
    {
        private readonly XName formatterName = XName.Get("customEventTextFormatter", Constants.Namespace);

        public bool CanCreateFormatter(XElement element)
        {
            return this.GetFormatterElement(element) != null;
        }

        public IEventTextFormatter CreateFormatter(XElement element)
        {
            return XmlUtil.CreateInstance<IEventTextFormatter>(this.GetFormatterElement(element));
        }

        private XElement GetFormatterElement(XElement element)
        {
            return element.Element(this.formatterName);
        }
    }
}
