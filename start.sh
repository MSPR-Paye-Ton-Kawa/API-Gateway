#!/bin/bash

# Tirer les images
docker pull "${DOCKERHUB_USERNAME}/api_gateway:latest"
docker pull "${DOCKERHUB_USERNAME}/client:latest"
docker pull "${DOCKERHUB_USERNAME}/produits:latest"
docker pull "${DOCKERHUB_USERNAME}/commandes:latest"

# Lancer les services avec Docker Compose
docker-compose up
