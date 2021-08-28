#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ApiGateways/Shopping.Aggregrator/Shopping.Aggregrator.csproj", "ApiGateways/Shopping.Aggregrator/"]
RUN dotnet restore "ApiGateways/Shopping.Aggregrator/Shopping.Aggregrator.csproj"
COPY . .
WORKDIR "/src/ApiGateways/Shopping.Aggregrator"
RUN dotnet build "Shopping.Aggregrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopping.Aggregrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Aggregrator.dll"]
