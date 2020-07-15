#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["OnlineStore.Catalog/OnlineStore.Catalog.csproj", "OnlineStore.Catalog/"]
COPY ["Common/OnlineStore.Common/OnlineStore.Common.csproj", "Common/OnlineStore.Common/"]
COPY ["Common/OnlineStore.JwtAuthentication/OnlineStore.JwtAuthentication.csproj", "Common/OnlineStore.JwtAuthentication/"]
RUN dotnet restore "OnlineStore.Catalog/OnlineStore.Catalog.csproj"
COPY . .
WORKDIR "/src/OnlineStore.Catalog"
RUN dotnet build "OnlineStore.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineStore.Catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineStore.Catalog.dll"]