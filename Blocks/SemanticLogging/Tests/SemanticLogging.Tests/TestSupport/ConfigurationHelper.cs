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

using System.Configuration;
using Microsoft.Win32;

namespace EntLibExtensions.SemanticLogging.Tests.TestSupport
{
    internal class ConfigurationHelper
    {
        public static string GetSetting(string settingName)
        {
            string value = null;
            using (var subKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\EntLib") ?? Registry.CurrentUser)
            {
                var keyValue = subKey.GetValue(settingName);
                if (keyValue != null)
                {
                    value = keyValue.ToString();
                }
            }

            if (string.IsNullOrEmpty(value))
            {
                value = ConfigurationManager.AppSettings[settingName];
            }

            return value;
        }
    }
}
