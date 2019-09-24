FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MTEngine/MTEngine.csproj", "MTEngine/"]
RUN dotnet restore "MTEngine/MTEngine.csproj"
COPY . .
WORKDIR "/src/MTEngine"
RUN dotnet build "MTEngine.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MTEngine.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MTEngine.dll"]