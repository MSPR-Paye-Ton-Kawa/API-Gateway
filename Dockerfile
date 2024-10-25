# Utilisez l'image SDK pour construire, publier, et tester
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiez les fichiers de projet
COPY API_Gateway/API_Gateway.csproj API_Gateway/
COPY API_Gateway.Tests/API_Gateway.Tests.csproj API_Gateway.Tests/

# Restaurer les d�pendances
RUN dotnet restore API_Gateway/API_Gateway.csproj
RUN dotnet restore API_Gateway.Tests/API_Gateway.Tests.csproj

# Copiez tous les fichiers sources
COPY . .

# Construisez les projets
WORKDIR /src/API_Gateway
RUN dotnet build -c Release -o /app/build

WORKDIR /src/API_Gateway.Tests
RUN dotnet build -c Release -o /app/build

# Ex�cutez les tests
WORKDIR /src/API_Gateway.Tests
RUN dotnet test --no-restore --verbosity normal

# Publiez le projet API_Gateway
WORKDIR /src/API_Gateway
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Utilisez l'image de base .NET pour ASP.NET Core pour la phase finale
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API_Gateway.dll"]