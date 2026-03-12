FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:sha256:512d643dce0e7daa25c85407eb4e14dbea33b72e4a7792427949666636934019 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:sha256:ea13841f10c6c410a6df63c6c97ab549dfd2b5fcfff1c00186531ba30208117d AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["src/TakeawayFinder.Api/TakeawayFinder.Api.csproj", "TakeawayFinder.Api/"]
COPY ["src/TakeawayFinder.Models/TakeawayFinder.Models.csproj", "TakeawayFinder.Models/"]
RUN dotnet restore "TakeawayFinder.Api/TakeawayFinder.Api.csproj"
COPY ["src/TakeawayFinder.Api/", "TakeawayFinder.Api/"]
COPY ["src/TakeawayFinder.Models/", "TakeawayFinder.Models/"]
RUN dotnet build "TakeawayFinder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "TakeawayFinder.Api.dll"]