run:
	dotnet run --project Cli/Cli.csproj

build:
	dotnet clean
	dotnet build -m

test:
	dotnet test

dbUpdate:
	dotnet ef database update --project Features/
