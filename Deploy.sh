docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker build
docker push