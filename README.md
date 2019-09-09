# MarketingPageAcceptanceTests

## Introduction
The Acceptance tests are an ongoing project that will be expanded to match the Marketing Page as it is developed. It utilises Selenium Grid (See [here](https://www.seleniumhq.org/docs/07_selenium_grid.jsp) for more info) to ensure driver and browser versions and types are independent of the solution.

## Environment Variables
All environment variables used in this repo are at Process level (i.e. in the same console window as the `dotnet test` command is performed)

| Variable | Example | Default |
|---------------|------------------|------------------|
| BROWSER | `chrome` | `chrome-local`<sup>1</sup> |
| MPURL | `http://publicbrowse.nhs.net` | `http://10.0.75.1:3000`<sup>2</sup> |
| HUBURL | `http://localhost:4444/wd/hub` | `http://localhost:4444/wd/hub` |

<sup>1</sup> - `chrome-local` should only be used for debugging. It will use the local instance of chrome rather than the Selenium Grid nodes to run the tests

<sup>2</sup> - `10.0.75.1:3000` is the external address when running the Marketing Page locally, this way the nodes in the hub can connect to it without issue