# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY SmartELK.API/*.csproj ./SmartELK.API/
COPY SmartELK.Domain/*.csproj ./SmartELK.Domain/
COPY SmartELK.Infrastructure/*.csproj ./SmartELK.Infrastructure/

WORKDIR /app/SmartELK.API
RUN dotnet restore

# Copy everything else and build
WORKDIR /app
COPY . .
RUN dotnet publish -c ${BUILD_CONFIGURATION} -o out

# Stage 2: Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "SmartELK.API.dll"]
