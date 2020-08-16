#!/bin/sh
DOCKER_TAG='latest'

docker info
apk update
apk upgrade
apk add python python-dev py-pip build-base libffi-dev openssl-dev
pip install docker-compose
docker login -u $CI_REGISTRY_USER -p "$CI_REGISTRY_PASSWORD" $CI_REGISTRY
docker build -t registry.gitlab.com/ruzanowski/foodbox/foodbox:$DOCKER_TAG .
docker push registry.gitlab.com/ruzanowski/ubiquitous/productservice:$DOCKER_TAG
