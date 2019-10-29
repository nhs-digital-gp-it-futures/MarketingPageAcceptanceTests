using MarketingPageAcceptanceTests.Actions.Collections;
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
                Common = new Common(driver, helper),
                Dashboard = new Dashboard(driver, helper),
                EditFeatures = new EditFeatures(driver, helper),
                SolutionDescription = new SolutionDescription(driver, helper),
                PreviewPage = new PreviewPage(driver, helper),
                ClientApplicationTypes = new ClientApplicationTypes(driver, helper),
                BrowserSubDashboard = new BrowserSubDashboard(driver, helper),
                BrowsersSupported = new BrowsersSupported(driver, helper)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
