using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace MarketingPageAcceptanceTests.Utils
{
    internal sealed class BrowserFactory
    {
        internal static IWebDriver GetBrowser(string browser, string huburl)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                case "googlechrome":
                    return GetChromeDriver(huburl);
                case "firefox":
                case "ff":
                case "mozilla":
                    return GetFirefoxDriver(huburl);
                case "chrome-local":
                    return GetLocalChromeDriver();
            }

            throw new WebDriverException($"Browser {browser} not supported");
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
            options.AddArguments("headless", "window-size=1920,1080");

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
