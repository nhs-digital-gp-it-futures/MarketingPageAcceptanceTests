using MarketingPageAcceptanceTests.Actions.Models;
using MarketingPageAcceptanceTests.Actions.Pages;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver, ITestOutputHelper helper)
        {
            PageActionCollection = new PageActionCollection
            {
                Common = new Common(driver, helper)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
