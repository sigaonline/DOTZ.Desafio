#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DOTZ.Desafio.API/DOTZ.Desafio.API.csproj", "DOTZ.Desafio.API/"]
RUN dotnet restore "DOTZ.Desafio.API/DOTZ.Desafio.API.csproj"
COPY . .
WORKDIR "/src/DOTZ.Desafio.API"
RUN dotnet build "DOTZ.Desafio.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOTZ.Desafio.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOTZ.Desafio.API.dll"]
