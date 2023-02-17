FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DbOtusConsole/DbOtusConsole.csproj", "DbOtusConsole/"]
RUN dotnet restore "DbOtusConsole/DbOtusConsole.csproj"
COPY . .
WORKDIR "/src/DbOtusConsole"
RUN dotnet build "DbOtusConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbOtusConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbOtusConsole.dll"]
