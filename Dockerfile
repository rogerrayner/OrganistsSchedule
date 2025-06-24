# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj -c Release -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["sh", "-c", "dotnet ef database update --no-build --project /src/OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj --startup-project /src/OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj && dotnet OrganistsSchedule.WebApi.dll"]