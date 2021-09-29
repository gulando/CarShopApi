FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarShopApi/CarShopApi.csproj", "CarShopApi/"]
RUN dotnet restore "CarShopApi/CarShopApi.csproj"
COPY . .
WORKDIR "/src/CarShopApi"
RUN dotnet build "CarShopApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarShopApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarShopApi.dll"]
