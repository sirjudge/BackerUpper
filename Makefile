run:
	dotnet run --project Cli/Cli.csproj

build:
	dotnet clean
	dotnet build

test:
	dotnet test
