FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY BookLibrary.csproj ./
RUN dotnet restore "BookLibrary.csproj"
COPY . .
RUN dotnet build "BookLibrary.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "BookLibrary.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookLibrary.dll"]
