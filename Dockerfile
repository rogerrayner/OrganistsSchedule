FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
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
COPY --from=publish /root/.dotnet/tools /root/.dotnet/tools
ENV PATH="$PATH:/root/.dotnet/tools"

# Install EF Core tools no stage final também
RUN dotnet tool install --global dotnet-ef

# Copia os arquivos do projeto para um diretório separado para migrations
COPY --from=build /src /src

# Script que roda migrations e depois inicia a API
RUN echo '#!/bin/bash\nset -e\necho "Running migrations..."\ncd /src\ndotnet ef database update --project OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj\necho "Starting API..."\ncd /app\ndotnet OrganistsSchedule.WebApi.dll' > /app/start.sh
RUN chmod +x /app/start.sh

CMD ["/app/start.sh"]
