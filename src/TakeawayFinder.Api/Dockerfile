FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5101
EXPOSE 7211

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TakeawayFinder.Api.csproj", "./"]
RUN dotnet restore "TakeawayFinder.Api/TakeawayFinder.Api.csproj"
COPY . .
WORKDIR "/src/TakeawayFinder.Api"
RUN dotnet build "./TakeawayFinder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TakeawayFinder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TakeawayFinder.Api.dll"]
