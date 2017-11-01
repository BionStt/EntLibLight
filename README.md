# EntLibExtensions
Modifications and extensions of Enterprise Library application blocks.

1. Semantic Logging application block modified to use EventSource from "Microsoft.Diagnostics.Tracing" namespace.
2. Added support for Elasticsearch sink
3. New "Infrastructure" application block with Unity container integration to simplify development of window services with scheduled/repeatable actions, launching external processes, and much more.
4. Added async support and default exception shielding  to "Exception Handling" Application Block



Nuget packages:
- https://www.nuget.org/packages/EntLibExtensions.SemanticLogging
- https://www.nuget.org/packages/EntLibExtensions.SemanticLogging.Database
- https://www.nuget.org/packages/EntLibExtensions.SemanticLogging.Elasticsearch
- https://www.nuget.org/packages/EntLibExtensions.SemanticLogging.Service
- https://www.nuget.org/packages/EntLibExtensions.Infrastructure
- https://www.nuget.org/packages/EntLibExtensions.Infrastructure.Unity5
- https://www.nuget.org/packages/EntLibExtensions.ExceptionHandling
