using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Common
    {
        private IWebDriver driver;
        private ITestOutputHelper helper;

        public Common(IWebDriver driver, ITestOutputHelper helper)
        {
            this.driver = driver;
            this.helper = helper;
        }
    }
}
