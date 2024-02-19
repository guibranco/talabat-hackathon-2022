FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0.101 AS build
WORKDIR /src
COPY ["src/TalabatHackathon.API/TalabatHackathon.API.csproj", "TalabatHackathon.API/"]
RUN dotnet restore "TalabatHackathon.API/TalabatHackathon.API.csproj"
COPY ./src .
WORKDIR "/src/TalabatHackathon.API"
RUN dotnet build "TalabatHackathon.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TalabatHackathon.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

HEALTHCHECK CMD curl --fail http://localhost:$PORT/health || exit

CMD ASPNETCORE_URLS=http://*:$PORT dotnet TalabatHackathon.API.dll