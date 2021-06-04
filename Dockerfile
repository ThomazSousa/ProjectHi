FROM mcr.microsoft.com/dotnet/core/sdk:3.1.401-alpine3.12 AS build
WORKDIR /src

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.7-alpine3.12 AS base
WORKDIR /app

FROM build AS publish
COPY . .
WORKDIR "/src/HiPlatform.Chat.Api"
RUN dotnet publish "HiPlatform.Chat.Api.csproj" -c Debug -o /app

FROM base AS final
ARG AspNetCoreEnvironment

ENV ASPNETCORE_ENVIRONMENT $AspNetCoreEnvironment
ENV ASPNETCORE_URLS http://+:5000

WORKDIR /app
COPY --from=publish /app .

EXPOSE 5000
ENTRYPOINT ["dotnet", "HiPlatform.Chat.Api.dll"]
