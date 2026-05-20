FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SaaSManagement.Web/SaaSManagement.Web.Client/SaaSManagement.Web.Client.csproj", "SaaSManagement.Web/SaaSManagement.Web.Client/"]
RUN dotnet restore "SaaSManagement.Web/SaaSManagement.Web.Client/SaaSManagement.Web.Client.csproj"
COPY . .
WORKDIR "/src/SaaSManagement.Web/SaaSManagement.Web.Client"
RUN dotnet build "./SaaSManagement.Web.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SaaSManagement.Web.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaaSManagement.Web.Client.dll"]
