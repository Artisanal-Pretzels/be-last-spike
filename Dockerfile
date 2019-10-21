FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["LastSpikeApi/LastSpikeApi.csproj", "LastSpikeApi/"]
RUN dotnet restore "LastSpikeApi/LastSpikeApi.csproj"
COPY . .
WORKDIR "/src/LastSpikeApi"
RUN dotnet build "LastSpikeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LastSpikeApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LastSpikeApi.dll"]
