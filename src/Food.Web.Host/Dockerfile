FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj .
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
ENV ASPNETCORE_URLS http://*:990
ENTRYPOINT ["dotnet", "Food.Web.Host.dll"]
