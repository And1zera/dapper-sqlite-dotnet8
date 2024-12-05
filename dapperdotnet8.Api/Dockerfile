#Nhelper Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

#COPY *.csproj
COPY ["dapperdotnet8.Api/dapperdotnet8.Api.csproj", "dapperdotnet8.Api/"]
COPY ["dapperdotnet8.Application/dapperdotnet8.Application.csproj", "dapperdotnet8.Application/"]
COPY ["dapperdotnet8.Data/dapperdotnet8.Data.csproj", "dapperdotnet8.Data/"]
COPY ["dapperdotnet8.Data.Postgres/dapperdotnet8.Data.Dapper.csproj", "dapperdotnet8.Data.Postgres/"]
COPY ["dapperdotnet8.Domain/dapperdotnet8.Domain.csproj", "dapperdotnet8.Domain/"]
COPY ["dapperdotnet8.IoC/dapperdotnet8.IoC.csproj", "dapperdotnet8.IoC/"]
COPY ["dapperdotnet8.Tests/dapperdotnet8.Tests.csproj", "dapperdotnet8.Tests/"]

RUN dotnet restore "./dapperdotnet8.Api/dapperdotnet8.Api.csproj"

COPY . .
WORKDIR "/src/dapperdotnet8.Api"
RUN dotnet publish "./dapperdotnet8.Api.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled AS final
WORKDIR /app
EXPOSE 8080

ENV TZ=America/Sao_Paulo \
    ASPNETCORE_URLS=http://*:8080

COPY --from=build /app/publish .

USER app

ENTRYPOINT ["dotnet", "dapperdotnet8.Api.dll"]
