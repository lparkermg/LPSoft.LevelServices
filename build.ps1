param(
    [string]$version="0.0.0"
)

dotnet test ./src/
dotnet pack ./src/LevelServices -p:PackageVersion=$version --output ./dist/