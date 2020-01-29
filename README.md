# MarketingPageAcceptanceTests

## Introduction
The Acceptance tests are an ongoing project that will be expanded to match the Marketing Page as it is developed. It utilises Selenium Grid (See below for more info) to ensure driver and browser versions and types are independent of the solution.

## Environment Variables
All environment variables used in this repo are at Process level (i.e. in the same console window as the `dotnet test` command is performed)

| Variable | Example | Default |
|---------------|------------------|------------------|
| BROWSER | `chrome` | `chrome-local`<sup>1</sup> |
| MPURL | `http://publicbrowse.nhs.net` | `http://hosts.docker.internal:3002/solution`<sup>2</sup> |
| HUBURL | `http://localhost:4444/wd/hub` | `http://localhost:4444/wd/hub` |
| SERVERURL | `http://dbinstance.local.com` | `127.0.0.1,1433` |
| DATABASENAME | `buyingcatalogue` | `buyingcatalogue` |
| DBUSER | `sa` | `NHSD` |
| DBPASSWORD | `Password123` | `DisruptTheMarket1!` |

To set a process level environment variable in a CLI see the below table

| CLI | Command | Example |
|---------------|--------------------|---------------
|`bash` | `export` | `export BROWSER=chrome` |
| `cmd` | `set` | `set BROWSER=chrome`|
| `PowerShell` | `$env:` | `$env:BROWSER = "chrome"` |

<sup>1</sup> - `chrome-local` should only be used for debugging. It will use the local instance of chrome rather than the Selenium Grid nodes to run the tests

<sup>2</sup> - `hosts.docker.internal` is a reference to the external IP of the local machine set up by Docker automatically on docker start. It is stable across Windows and MacOS and ensures that less configuration is required to run the tests locally.

## Selenium Grid
Selenium grid is a distributed set of nodes linked to a master node that run the tests independently of each other then combine results. A docker-compose file has been provided to ease the setup of a grid, simply by running `docker-compose up -d`. THis will set up a very simple grid consisting of a hub, a chrome node and a firefox node. THe browser nodes can be scaled up by adding `--scale chrome=4` and/or `--scale firefox=4`, changing the value after the `=` symbol to however many nodes you require.

To close down the grid and stop the containers, simply run `docker-compose down --remove-orphans` and the grid will gracefully stop.
