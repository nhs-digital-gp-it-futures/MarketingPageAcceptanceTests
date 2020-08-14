using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    public sealed class BrowserFactory
    {
        private readonly Settings _settings;

        public BrowserFactory(Settings settings)
        {
            _settings = settings;
            Driver = GetBrowser();
        }

        public IWebDriver Driver { get; }

        private IWebDriver GetBrowser()
        {
            IWebDriver driver;
            var browser = _settings.Browser;
            var huburl = _settings.HubUrl;

            if (Debugger.IsAttached)
                driver = GetLocalChromeDriver();
            else
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

            return driver;
        }

        private static IWebDriver GetLocalChromeDriver()
        {
            var options = DefaultChromeOptions(false);

            return new ChromeDriver(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), options);
        }

        private static IWebDriver GetChromeDriver(string hubUrl)
        {
            var options = DefaultChromeOptions(true);

            return new RemoteWebDriver(new Uri(hubUrl), options);
        }

        private static IWebDriver GetFirefoxDriver(string hubUrl)
        {
            var options = new FirefoxOptions();
            options.AddArguments("headless", "window-size=1920,1080", "no-sandbox", "acceptInsecureCerts");

            return new RemoteWebDriver(new Uri(hubUrl), options);
        }

        private static ChromeOptions DefaultChromeOptions(bool headless)
        {
            var options = new ChromeOptions();
            options.AddArguments("no-sandbox", "disable-dev-shm-usage", "ignore-certificate-errors");
            if (headless)
                options.AddArguments("headless", "window-size=1920,1080");
            else
                options.AddArguments("start-maximized", "auto-open-devtools-for-tabs");

            return options;
        }
    }
}
