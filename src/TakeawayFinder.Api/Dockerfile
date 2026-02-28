FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["src/TakeawayFinder.Api/TakeawayFinder.Api.csproj", "TakeawayFinder.Api/"]
COPY ["src/TakeawayFinder.Models/TakeawayFinder.Models.csproj", "TakeawayFinder.Models/"]
RUN dotnet restore "TakeawayFinder.Api/TakeawayFinder.Api.csproj"
COPY ["src/TakeawayFinder.Api/", "TakeawayFinder.Api/"]
COPY ["src/TakeawayFinder.Models/", "TakeawayFinder.Models/"]
WORKDIR "/src/TakeawayFinder.Api"
RUN dotnet build "TakeawayFinder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TakeawayFinder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE $PORT

ENTRYPOINT ["dotnet", "TakeawayFinder.Api.dll"]