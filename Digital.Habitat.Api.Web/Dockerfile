#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Digital.Habitat.Api.Web/Digital.Habitat.Api.Web.csproj", "Digital.Habitat.Api.Web/"]
RUN dotnet restore "Digital.Habitat.Api.Web/Digital.Habitat.Api.Web.csproj"
COPY . .
WORKDIR "/src/Digital.Habitat.Api.Web"
RUN dotnet build "Digital.Habitat.Api.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Digital.Habitat.Api.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Digital.Habitat.Api.Web.dll"]