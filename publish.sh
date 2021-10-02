docker build -t S5Backend .
docker tag S5Backend idi2019.azurecr.io/dwo1327-S5Backend
docker push idi2019.azurecr.io/dwo1327-S5Backend