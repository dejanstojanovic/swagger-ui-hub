#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Swagger.UI.Hub/Swagger.UI.Hub.csproj", "Swagger.UI.Hub/"]
RUN dotnet restore "Swagger.UI.Hub/Swagger.UI.Hub.csproj"
COPY . .
WORKDIR "/src/Swagger.UI.Hub"
RUN dotnet build "Swagger.UI.Hub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swagger.UI.Hub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swagger.UI.Hub.dll"]