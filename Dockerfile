# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the solution file
COPY Server/RockPaperScissorsServer.sln Server/ 

# Copy the project files
COPY Dependencies/ApplicationInfrastructure/Core/Kernel/Kernel.csproj Dependencies/ApplicationInfrastructure/Core/Kernel/
COPY Server/Model/RockPaperScissors.Model.csproj Server/Model/
COPY Server/Repository/RockPaperScissors.Repository.csproj Server/Repository/
COPY Server/Service/RockPaperScissors.Service.csproj Server/Service/
COPY Server/Api/RockPaperScissors.Api.csproj Server/Api/

# Restore the solution
RUN dotnet restore Server/RockPaperScissorsServer.sln

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet publish Server/Api/RockPaperScissors.Api.csproj -c Release -o /app/publish

# Use the official ASP.NET runtime image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 80

# Set the entry point for the app
ENTRYPOINT ["dotnet", "RockPaperScissors.Api.dll"]
