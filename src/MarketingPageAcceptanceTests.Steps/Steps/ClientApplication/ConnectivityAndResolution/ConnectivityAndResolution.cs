namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.ConnectivityAndResolution
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class ConnectivityAndResolution : TestBase
    {
        private string expectedMinimumConnectionSpeed;
        private string expectedMinimumDesktopResolution;

        public ConnectivityAndResolution(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a User has provided a value for the Connectivity and resolution Mandatory Information")]
        public void GivenThatAUserHasProvidedAValueForTheConnectivityAndResolutionMandatoryInformation()
        {
            test.Pages.Dashboard.NavigateToSection("Browser-based", true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Connectivity and resolution");

            expectedMinimumConnectionSpeed = "0.5Mbps";
            expectedMinimumDesktopResolution = "4:3 - 800 x 600";
            test.Pages.BrowserBasedSections.ConnectivityAndResolution.SelectMinimumConnectionSpeed(
                expectedMinimumConnectionSpeed);
            test.Pages.BrowserBasedSections.ConnectivityAndResolution.SelectMinimumDesktopResolution(
                expectedMinimumDesktopResolution);
        }

        [Then(@"the Connectivity and resolution details match as expected on the Preview of the Marketing Page")]
        public void ThenTheConnectivityAndResolutionDetailsMatchAsExpectedOnThePreviewOfTheMarketingPage()
        {
            var actualMinimumConnectionSpeed = test.Pages.PreviewPage.GetConnectivityRequirement();
            var actualMinimumDesktopResolution = test.Pages.PreviewPage.GetDesktopResolutionRequirement();

            actualMinimumConnectionSpeed.Should().Be(expectedMinimumConnectionSpeed);
            actualMinimumDesktopResolution.Should().Be(expectedMinimumDesktopResolution);
        }
    }
}
