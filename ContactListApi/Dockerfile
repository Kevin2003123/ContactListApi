#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ContactListApi/ContactListApi.csproj", "ContactListApi/"]
RUN dotnet restore "ContactListApi/ContactListApi.csproj"
COPY . .
WORKDIR "/src/ContactListApi"
RUN dotnet build "ContactListApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactListApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactListApi.dll"]


#RUN /opt/mssql/bin/sqlservr --accept-eula & sleep 30  & /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Carta14123!' -d master -i /opt/scripts/database.sql