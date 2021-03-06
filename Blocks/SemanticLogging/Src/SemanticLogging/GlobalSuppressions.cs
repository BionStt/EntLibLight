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

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

// Suppressions for general exceptions caught and logged
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Formatters.EventTextFormatter.#FormatPayload(EntLibExtensions.SemanticLogging.EventEntry)", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.ObservableEventListener.#OnEventWritten(System.Diagnostics.Tracing.EventWrittenEventArgs)", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Sinks.ConsoleSink.#OnNext(System.String,System.Nullable`1<System.ConsoleColor>)", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Sinks.FlatFileSink.#OnSingleEventWritten(System.String)", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Sinks.FlatFileSink.#WriteEntries()", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Sinks.RollingFlatFileSink.#OnSingleEventWritten(System.String)", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Sinks.RollingFlatFileSink.#WriteEntries()", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Utility.EventEntryExtensions.#TryFormatAsString(EntLibExtensions.SemanticLogging.EventEntry,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter)", Justification = "Exceptions are logged")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Utility.EventEntryExtensions.#TryFormatAsStringAndColor(EntLibExtensions.SemanticLogging.EventEntry,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,EntLibExtensions.SemanticLogging.Formatters.IConsoleColorMapper)", Justification = "Exceptions are logged")]

// Suppressions for casing of Opcode
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Opcode", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Schema.EventSchema.#OpcodeName", Justification = "Uses casing from EventWrittenEventArgs.Opcode")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "opcode", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Schema.EventSchema.#.ctor(System.Int32,System.Guid,System.String,System.Diagnostics.Tracing.EventLevel,System.Diagnostics.Tracing.EventTask,System.String,System.Diagnostics.Tracing.EventOpcode,System.String,System.Diagnostics.Tracing.EventKeywords,System.String,System.Int32,System.Collections.Generic.IEnumerable`1<System.String>)", Justification = "Uses casing from EventWrittenEventArgs.Opcode")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Opcode", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Schema.EventSchema.#Opcode", Justification = "Uses casing from EventWrittenEventArgs.Opcode")]

// Suppressions for default parameters
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.ConsoleLog.#LogToConsole(System.IObservable`1<EntLibExtensions.SemanticLogging.EventEntry>,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,EntLibExtensions.SemanticLogging.Formatters.IConsoleColorMapper)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.ConsoleLog.#CreateListener(EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,EntLibExtensions.SemanticLogging.Formatters.IConsoleColorMapper)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Formatters.EventTextFormatter.#.ctor(System.String,System.String,System.Diagnostics.Tracing.EventLevel,System.String)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.FlatFileLog.#LogToFlatFile(System.IObservable`1<EntLibExtensions.SemanticLogging.EventEntry>,System.String,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,System.Boolean)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.FlatFileLog.#CreateListener(System.String,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,System.Boolean)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Formatters.JsonEventTextFormatter.#.ctor(EntLibExtensions.SemanticLogging.Formatters.EventTextFormatting,System.String)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.RollingFlatFileLog.#LogToRollingFlatFile(System.IObservable`1<EntLibExtensions.SemanticLogging.EventEntry>,System.String,System.Int32,System.String,EntLibExtensions.SemanticLogging.Sinks.RollFileExistsBehavior,EntLibExtensions.SemanticLogging.Sinks.RollInterval,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,System.Int32,System.Boolean)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.RollingFlatFileLog.#CreateListener(System.String,System.Int32,System.String,EntLibExtensions.SemanticLogging.Sinks.RollFileExistsBehavior,EntLibExtensions.SemanticLogging.Sinks.RollInterval,EntLibExtensions.SemanticLogging.Formatters.IEventTextFormatter,System.Int32,System.Boolean)", Justification = "As designed.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "EntLibExtensions.SemanticLogging.Formatters.XmlEventTextFormatter.#.ctor(EntLibExtensions.SemanticLogging.Formatters.EventTextFormatting,System.String)", Justification = "As designed.")]
