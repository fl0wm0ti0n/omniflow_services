#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080

# get pingtools
RUN apt-get update && apt-get install -y iputils-ping && apt-get clean

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NodeMonitor/NodeMonitor.csproj", "NodeMonitor/"]
COPY ["DatabaseLib/DatabaseLib.csproj", "DatabaseLib/"]
COPY ["InterfacesLib/InterfacesLib.csproj", "InterfacesLib/"]
COPY ["DataTransferObjects/DataTransferObjects.csproj", "DataTransferObjects/"]
RUN dotnet restore "NodeMonitor/NodeMonitor.csproj"
COPY . .
WORKDIR "/src/nodemon"
RUN dotnet build "NodeMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NodeMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nodemon.dll"]