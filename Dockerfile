FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj", "OrganistsSchedule.WebApi/"]
RUN dotnet restore "OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj"
COPY . .
WORKDIR "/src/OrganistsSchedule.WebApi"
RUN dotnet build "OrganistsSchedule.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrganistsSchedule.WebApi.csproj" -c Release -o /app/publish

# Install EF Core tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/tools /root/.dotnet/tools
ENV PATH="$PATH:/root/.dotnet/tools"

# Script que roda migrations e depois inicia a API
COPY --from=build /src .
RUN echo '#!/bin/bash\ndotnet ef database update --project OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj\ndotnet OrganistsSchedule.WebApi.dll' > /app/start.sh
RUN chmod +x /app/start.sh

CMD ["/app/start.sh"]
