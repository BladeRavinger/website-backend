# Use an official Python runtime as a base image
FROM microsoft/dotnet:1.1-sdk

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY /build_output /app

ENTRYPOINT ["dotnet", "UKSFWebsite.api.dll"]