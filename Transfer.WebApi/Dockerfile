
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Transfer.WebApi.csproj", "./"]
RUN dotnet restore "Transfer.WebApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Transfer.WebApi.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Transfer.WebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transfer.WebApi.dll"]