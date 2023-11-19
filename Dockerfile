# Use the official .NET SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file to the working directory
COPY *.csproj .

# Restore NuGet packages
RUN dotnet restore

# Copy the remaining files to the working directory
COPY . .

# Build the application
RUN dotnet build -c Release -o out

# Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/out .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Pamiw6.dll"]
