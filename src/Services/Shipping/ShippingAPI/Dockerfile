FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Shipping/ShippingAPI/ShippingAPI.csproj", "src/Services/Shipping/ShippingAPI/"]
COPY ["src/Services/Shipping/Infra/Infra.csproj", "src/Services/Shipping/Infra/"]
COPY ["src/Services/Shipping/ApplicationCore/ApplicationCore.csproj", "src/Services/Shipping/ApplicationCore/"]
RUN dotnet restore "src/Services/Shipping/ShippingAPI/ShippingAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/Shipping/ShippingAPI"
RUN dotnet build "ShippingAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShippingAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShippingAPI.dll"]
