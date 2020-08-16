FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj .
COPY Food.Application/*.csproj ./Food.Application
COPY Food.Core/*.csproj ./Food.Core
COPY Food.EntityFrameworkCore/*.csproj ./Food.EntityFrameworkCore
COPY Food.Migrator/*.csproj ./Food.Migrator
COPY Food.Web.Core/*.csproj ./Food.Web.Core
COPY Food.Web.Host/*.csproj ./Food.Web.Host
COPY . .
RUN dotnet restore

# copy everything else and build app
WORKDIR /source
COPY . .
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build /app ./

# environment variables
ENV ASPNETCORE_URLS http://*:9901
ENTRYPOINT ["dotnet", "Food.Web.Host.dll"]
