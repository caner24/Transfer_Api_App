# Start with a base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the .csproj file
COPY C:/Users/cnr24/source/repos/Transfer_Api_App/Transfer.WebApi/Transfer.WebApi.csproj .

# Restore NuGet packages
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build -c Release -o out

# Set the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory
WORKDIR /app

# Copy the built application from the build environment
COPY --from=build-env /app/out .

# Expose the necessary port
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "Transfer.WebApi.dll"]