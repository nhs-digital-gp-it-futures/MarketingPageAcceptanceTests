#!/bin/bash

timeout=${SETUP_TIMEOUT:-600}
additionalDotnetArgs=""

echo "Waiting for $PBURL to be ready..."

n=0
until [ "$n" -ge "$timeout" ]; do
  httpStatusCode=$(curl -I -s --insecure $PBURL | cat | head -n 1 | cut -d" " -f2)

  if [ "$httpStatusCode" = "200" ]; then echo "$PBURL was ready in $n seconds" && break; fi
  n=$((n+1)) 
  sleep 1
done

if [ "$n" -eq "$timeout" ]; then echo "$PBURL is not ready after $n seconds" && exit 1; fi


if [ -n "${TEST_RESULT_DIR}" ]; then
  echo "Directing test results to '$TEST_RESULT_DIR'"
  additionalDotnetArgs+="--logger trx --results-directory $TEST_RESULT_DIR "
fi

if [ -n "${TEST_FILTER}" ]; then
  echo "Running only tests annotated with '@$TEST_FILTER'"
  additionalDotnetArgs+="--filter TestCategory=$TEST_FILTER "
fi

cmd="dotnet test out/MarketingPageAcceptanceTests.AuthorityTests.dll -v n $additionalDotnetArgs"
echo -e "\n Running '$cmd' \n"
eval $cmd

cmd="dotnet test out/MarketingPageAcceptanceTests.SupplierTests.dll -v n $additionalDotnetArgs"
echo -e "\n Running '$cmd' \n"
eval $cmd

cmd="dotnet test out/MarketingPageAcceptanceTests.SmokeTests.dll -v n $additionalDotnetArgs"
echo -e "\n Running '$cmd' \n"
eval $cmd