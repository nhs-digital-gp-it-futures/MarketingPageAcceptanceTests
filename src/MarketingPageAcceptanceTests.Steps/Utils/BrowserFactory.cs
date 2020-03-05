using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    public sealed class BrowserFactory
    {
        public IWebDriver Driver { get; }

        public BrowserFactory()
        {
            var browser = EnvironmentVariables.GetBrowser();
            var hubUrl = EnvironmentVariables.GetHubUrl();
            Driver = GetBrowser(browser, hubUrl);
        }

        private IWebDriver GetBrowser(string browser, string hubUrl)
        {
            IWebDriver driver;

            if (System.Diagnostics.Debugger.IsAttached)
            {
                driver = LocalChromeDriver();
            }
            else
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                    case "googlechrome":
                        driver = ChromeDriver(hubUrl);
                        break;
                    case "firefox":
                    case "ff":
                    case "mozilla":
                        driver = FirefoxDriver(hubUrl);
                        break;
                    case "chrome-local":
                        driver = LocalChromeDriver();
                        break;
                    default:
                        throw new WebDriverException($"Browser {browser} not supported");
                }
            }

            return driver;
        }

        private static IWebDriver LocalChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized", "no-sandbox", "auto-open-devtools-for-tabs");

            return new ChromeDriver(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), options);
        }

        private static IWebDriver ChromeDriver(string hubURL)
        {
            var options = new ChromeOptions();
            options.AddArguments("headless", "window-size=1920,1080", "no-sandbox", "disable-dev-shm-usage");

            return RemoteDriver(new Uri(hubURL), options);
        }

        private static IWebDriver FirefoxDriver(string hubURL)
        {
            var options = new FirefoxOptions();
            options.AddArguments("headless", "window-size=1920,1080", "no-sandbox");

            return RemoteDriver(new Uri(hubURL), options);
        }
        private static IWebDriver RemoteDriver(Uri uri, DriverOptions options)
        {
            IWebDriver driver = null;

            Policies.GetPolicy().Execute(() =>
            {
                driver = new RemoteWebDriver(uri, options);
            });

            return driver;
        }
    }
}
