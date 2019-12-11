using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace MarketingPageAcceptanceTestsSpecflow.Utils
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

        private IWebDriver GetBrowser(string browser, string huburl)
        {
            IWebDriver driver;

            if (System.Diagnostics.Debugger.IsAttached)
            {
                driver = GetLocalChromeDriver();
            }
            else
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                    case "googlechrome":
                        driver = GetChromeDriver(huburl);
                        break;
                    case "firefox":
                    case "ff":
                    case "mozilla":
                        driver = GetFirefoxDriver(huburl);
                        break;
                    case "chrome-local":
                        driver = GetLocalChromeDriver();
                        break;
                    default:
                        throw new WebDriverException($"Browser {browser} not supported");
                }
            }

            return driver;
        }

        private static IWebDriver GetLocalChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized", "no-sandbox", "auto-open-devtools-for-tabs");

            return new ChromeDriver(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), options);
        }

        private static IWebDriver GetChromeDriver(string hubURL)
        {
            var options = new ChromeOptions();
            options.AddArguments("headless", "window-size=1920,1080"/*, "no-sandbox"*/);

            return new RemoteWebDriver(new Uri(hubURL), options);
        }

        private static IWebDriver GetFirefoxDriver(string hubURL)
        {
            var options = new FirefoxOptions();
            options.AddArguments("headless", "window-size=1920,1080", "no-sandbox");

            return new RemoteWebDriver(new Uri(hubURL), options);
        }
    }
}
