FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50467
EXPOSE 44320

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY IndoorTracker.API/IndoorTracker.API.csproj IndoorTracker.API/
RUN dotnet restore IndoorTracker.API/IndoorTracker.API.csproj
COPY . .
WORKDIR /src/IndoorTracker.API
RUN dotnet build IndoorTracker.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish IndoorTracker.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IndoorTracker.API.dll"]
