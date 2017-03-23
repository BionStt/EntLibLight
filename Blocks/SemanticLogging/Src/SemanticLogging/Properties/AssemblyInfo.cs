#region license
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

using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[assembly: AssemblyTitle("Enterprise Library Semantic Logging Application Block")]
[assembly: AssemblyDescription("Enterprise Library Semantic Logging Application Block")]

[assembly: SecurityTransparent]

[assembly: AssemblyVersion("1.0.1.0")]
[assembly: AssemblyFileVersion("1.0.1.0")]

[assembly: ComVisible(false)]
[assembly: NeutralResourcesLanguage("en-US")]

#if SIGN
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.WindowsAzure, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c15f3ece203f37fca77b84268bab3a94534b53dadf0bfa03a25649439235769e69b88b937cf9edf098638376e6305bb42d181b5c1961ceb9204bfd3a1ac77166d4c0167f4f3f529cd2f8327dfdf0524c928dd0c6581e6a380d9f8c6b59cd9c86173f3c64939770a10610163f12edfb8aa1d5db5ee67d9c71795263d12e5795c5")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Database, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c15f3ece203f37fca77b84268bab3a94534b53dadf0bfa03a25649439235769e69b88b937cf9edf098638376e6305bb42d181b5c1961ceb9204bfd3a1ac77166d4c0167f4f3f529cd2f8327dfdf0524c928dd0c6581e6a380d9f8c6b59cd9c86173f3c64939770a10610163f12edfb8aa1d5db5ee67d9c71795263d12e5795c5")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Etw, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c15f3ece203f37fca77b84268bab3a94534b53dadf0bfa03a25649439235769e69b88b937cf9edf098638376e6305bb42d181b5c1961ceb9204bfd3a1ac77166d4c0167f4f3f529cd2f8327dfdf0524c928dd0c6581e6a380d9f8c6b59cd9c86173f3c64939770a10610163f12edfb8aa1d5db5ee67d9c71795263d12e5795c5")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c15f3ece203f37fca77b84268bab3a94534b53dadf0bfa03a25649439235769e69b88b937cf9edf098638376e6305bb42d181b5c1961ceb9204bfd3a1ac77166d4c0167f4f3f529cd2f8327dfdf0524c928dd0c6581e6a380d9f8c6b59cd9c86173f3c64939770a10610163f12edfb8aa1d5db5ee67d9c71795263d12e5795c5")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.FunctionalTests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c15f3ece203f37fca77b84268bab3a94534b53dadf0bfa03a25649439235769e69b88b937cf9edf098638376e6305bb42d181b5c1961ceb9204bfd3a1ac77166d4c0167f4f3f529cd2f8327dfdf0524c928dd0c6581e6a380d9f8c6b59cd9c86173f3c64939770a10610163f12edfb8aa1d5db5ee67d9c71795263d12e5795c5")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Elasticsearch, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c15f3ece203f37fca77b84268bab3a94534b53dadf0bfa03a25649439235769e69b88b937cf9edf098638376e6305bb42d181b5c1961ceb9204bfd3a1ac77166d4c0167f4f3f529cd2f8327dfdf0524c928dd0c6581e6a380d9f8c6b59cd9c86173f3c64939770a10610163f12edfb8aa1d5db5ee67d9c71795263d12e5795c5")]
#else
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.WindowsAzure")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Database")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Etw")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Tests")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.FunctionalTests")]
[assembly: InternalsVisibleTo("EntLibExtensions.SemanticLogging.Elasticsearch")]
#endif