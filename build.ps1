param(
    [string]$version="0.0.0"
)

dotnet test ./src/ -c Release
dotnet pack ./src/LevelServices -c Release -p:PackageVersion=$version --output ./dist/