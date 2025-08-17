FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia todos os arquivos de projeto primeiro
COPY ["OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj", "OrganistsSchedule.WebApi/"]
COPY ["OrganistsSchedule.Infra.IoC/OrganistsSchedule.Infra.IoC.csproj", "OrganistsSchedule.Infra.IoC/"]
COPY ["OrganistsSchedule.Application/OrganistsSchedule.Application.csproj", "OrganistsSchedule.Application/"]
COPY ["OrganistsSchedule.Bff/OrganistsSchedule.Bff.csproj", "OrganistsSchedule.Bff/"]
COPY ["OrganistsSchedule.Domain/OrganistsSchedule.Domain.csproj", "OrganistsSchedule.Domain/"]
COPY ["OrganistsSchedule.Infra.Data/OrganistsSchedule.Infra.Data.csproj", "OrganistsSchedule.Infra.Data/"]

RUN dotnet restore "OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj"
COPY . .

WORKDIR "/src/OrganistsSchedule.WebApi"
RUN dotnet publish "OrganistsSchedule.WebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "OrganistsSchedule.WebApi.dll"]
