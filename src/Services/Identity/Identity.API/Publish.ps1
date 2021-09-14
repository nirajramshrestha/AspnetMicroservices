
(Get-IISAppPool "Identity").Recycle()
dotnet publish --self-contained false -r win10-x64 -o C:\Work\Workspace\PublishManifest\Identity
(Get-IISAppPool "Identity").Recycle()