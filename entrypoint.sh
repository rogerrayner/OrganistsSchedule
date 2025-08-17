#!/bin/sh
dotnet tool install --global dotnet-ef
export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update --project OrganistsSchedule.WebApi/OrganistsSchedule.WebApi.csproj
dotnet OrganistsSchedule.WebApi.dll
