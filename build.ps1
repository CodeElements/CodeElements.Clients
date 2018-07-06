dotnet build CodeElements.sln -c Release

Get-ChildItem ./CodeElements.Clients/*.pp -Recurse | ForEach-Object { Remove-Item $_ }

$files = (Get-ChildItem -Path ./CodeElements.Clients -Filter *.cs -File) +
         (Get-ChildItem -Path ./CodeElements.Clients/Extensions -Filter *.cs -File) +
         (Get-ChildItem -Path ./CodeElements.Clients/Helpers -Filter *.cs -File)

$files | ForEach-Object { 
    (Get-Content $_.FullName).Replace('YourRootNamespace.', '$rootnamespace$.') |
    Set-Content ($_.FullName + ".pp")
}

dotnet pack CodeElements.Clients/CodeElements.Clients.csproj -o ..\artifacts