#/bin/bash

export PBHOSTURL
docker-compose stop &&
docker-compose rm -f &&
docker-compose -f "docker-compose.yml" -f "docker-compose-pipeline.yml" up --scale chrome=4 -d

n=0
chromeNodeNames=$(docker ps --filter "name=chrome" --format "table {{.Names}}")
firstNode=$(echo $chromeNodeNames | cut -d" " -f2)

until [ "$n" -ge 30 ]
do
  status=$(docker inspect --format "{{json .State.Health.Status }}" "$firstNode" | tr -d '"')
  
  if [ "$status" = "healthy" ]; then echo "Selenium grid is ready" && exit 0; fi
  n=$((n+1)) 
  sleep 1
done

echo "Selenium grid cannot access $MPSUPPLIERURL"
exit 1
