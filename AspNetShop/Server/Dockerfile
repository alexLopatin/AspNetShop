#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AspNetShop/Server/AspNetShop.Server.csproj", "AspNetShop/Server/"]
COPY ["AspNetShop/Client/AspNetShop.Client.csproj", "AspNetShop/Client/"]
COPY ["AspNetShop/Shared/AspNetShop.Shared.csproj", "AspNetShop/Shared/"]
RUN dotnet restore "AspNetShop/Server/AspNetShop.Server.csproj"
COPY . .
WORKDIR "/src/AspNetShop/Server"
RUN dotnet build "AspNetShop.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetShop.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetShop.Server.dll"]