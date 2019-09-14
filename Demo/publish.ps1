#Win-x64
dotnet.exe publish -c Release -r win-x64 -o Publish\win-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#Win-x86
dotnet.exe publish -c Release -r win-x86 -o Publish\win-x86 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained
