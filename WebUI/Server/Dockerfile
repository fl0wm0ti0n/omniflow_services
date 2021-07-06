#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebUI/Server/WebUI.Server.csproj", "WebUI/Server/"]
COPY ["WebUI/Shared/WebUI.Shared.csproj", "WebUI/Shared/"]
COPY ["WebUI/Client/WebUI.Client.csproj", "WebUI/Client/"]
COPY ["DataTransferObjects/DataTransferObjects.csproj", "DataTransferObjects/"]
COPY ["InterfacesLib/InterfacesLib.csproj", "InterfacesLib/"]
COPY ["CommonLib/CommonLib.csproj", "CommonLib/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "WebUI/Server/WebUI.Server.csproj"
COPY . .
WORKDIR "/src/WebUI/Server"
RUN dotnet build "WebUI.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.Server.dll"]
