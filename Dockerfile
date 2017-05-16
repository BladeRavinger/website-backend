# Use an official Python runtime as a base image
FROM microsoft/aspnetcore

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
ADD /build_output /app

EXPOSE 80
EXPOSE 5000

ENTRYPOINT ["dotnet", "UKSFWebsite.api.dll"]