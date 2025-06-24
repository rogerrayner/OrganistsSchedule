# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update --no-build --project OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj --startup-project OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj
RUN dotnet publish OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "OrganistsSchedule.WebApi.dll"]