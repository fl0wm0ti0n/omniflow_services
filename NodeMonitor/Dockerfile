#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 55000
EXPOSE 55001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NodeMonitor/NodeMonitor.csproj", "NodeMonitor/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["CommonLib/CommonLib.csproj", "CommonLib/"]
COPY ["DatabaseLib/DatabaseLib.csproj", "DatabaseLib/"]
COPY ["InterfacesLib/InterfacesLib.csproj", "InterfacesLib/"]
COPY ["DataTransferObjects/DataTransferObjects.csproj", "DataTransferObjects/"]
RUN dotnet restore "NodeMonitor/NodeMonitor.csproj"
COPY . .
WORKDIR "/src/NodeMonitor"
RUN dotnet build "NodeMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NodeMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NodeMonitor.dll"]
