# Use the appropriate base image for your application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the appropriate target framework and publish your application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gas.WebAppAPI/Gas.WebAPI.csproj", "Gas.WebAppAPI/"]
RUN dotnet restore "Gas.WebAppAPI/Gas.WebAPI.csproj"
COPY . .
WORKDIR "/src/Gas.WebAppAPI"
RUN dotnet build "Gas.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gas.WebAPI.csproj" -c Release -o /app/publish

# Create the final image with the published application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gas.WebAPI.dll"]
