namespace MarketingPageAcceptanceTests.Steps.Utils
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;

    public sealed class BrowserFactory
    {
        private readonly Settings settings;

        public BrowserFactory(Settings settings)
        {
            this.settings = settings;
            Driver = GetBrowser();
        }

        public IWebDriver Driver { get; }

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
            {
                options.AddArguments("headless", "window-size=1920,1080");
            }
            else
            {
                options.AddArguments("start-maximized", "auto-open-devtools-for-tabs");
            }

            return options;
        }

        private IWebDriver GetBrowser()
        {
            IWebDriver driver;
            var browser = settings.Browser;
            var huburl = settings.HubUrl;

            if (Debugger.IsAttached)
            {
                driver = GetLocalChromeDriver();
            }
            else
            {
                driver = browser.ToLower() switch
                {
                    "chrome" or "googlechrome" => GetChromeDriver(huburl),
                    "firefox" or "ff" or "mozilla" => GetFirefoxDriver(huburl),
                    "chrome-local" => GetLocalChromeDriver(),
                    _ => throw new WebDriverException($"Browser {browser} not supported"),
                };
            }

            return driver;
        }
    }
}
