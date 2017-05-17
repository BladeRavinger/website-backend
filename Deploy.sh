docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker build frostebite/website-backend:dev
docker push frostebite/website-backend:dev