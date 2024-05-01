# Stage 1: Build the ASP.NET Core Web API project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY Gas.WebAppAPI/*.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 9998

ENTRYPOINT ["dotnet", "Gas.WebAPI.dll", "--urls", "http://0.0.0.0:9998"]
