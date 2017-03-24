nuget.exe pack "..\SemanticLogging\Src\SemanticLogging\SemanticLogging.csproj" -properties Configuration=Release -symbols
nuget.exe pack "..\SemanticLogging\Src\SemanticLogging.Database\SemanticLogging.Database.csproj" -properties Configuration=Release -symbols -includereferencedprojects
nuget.exe pack "..\SemanticLogging\Src\SemanticLogging.Elasticsearch\SemanticLogging.Elasticsearch.csproj" -properties Configuration=Release -symbols -includereferencedprojects
nuget.exe pack "..\SemanticLogging\Src\SemanticLogging.Etw.WindowsService\SemanticLogging.Etw.WindowsService.csproj" -properties Configuration=Release -tool -includereferencedprojects -symbols

nuget.exe pack "..\ExceptionHandling\Src\ExceptionHandling\ExceptionHandling.csproj" -properties Configuration=Release -symbols -includereferencedprojects
