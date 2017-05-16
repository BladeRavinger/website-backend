# Use an official Python runtime as a base image
FROM microsoft/dotnet:1.0-runtime

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY /build_output /app
COPY /build_output/website-backend-config /app/website-backend-config

ENTRYPOINT ["dotnet", "UKSFWebsite.api.dll"]