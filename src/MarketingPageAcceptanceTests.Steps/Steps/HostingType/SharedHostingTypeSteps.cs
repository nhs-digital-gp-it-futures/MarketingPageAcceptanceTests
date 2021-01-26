namespace MarketingPageAcceptanceTests.Steps
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class SharedHostingTypeSteps : TestBase
    {
        public SharedHostingTypeSteps(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Then(
            @"The (Public cloud|Private cloud|Hybrid|On premise) section (contains|does not contain) This Solution requires a HSCN/N3 connection on the preview of the marketing page")]
        public void ThenThePublicCloudSectionContainsThisSolutionRequiresAHSCNNConnectionOnThePreviewOfTheMarketingPage(
            string hostingTypeSection, string assertionText)
        {
            test.Pages.PreviewPage.IsRequiresHscnDisplayed(hostingTypeSection).Should()
               .Be(assertionText == "contains");
        }

        [Given(@"that (Public cloud|Private cloud|Hybrid|On premise) has been completed in the Hosting type section")]
        public void GivenThatPublicCloudHasBeenCompletedInTheHostingTypeSection(string hostingTypeSection)
        {
            test.Pages.Dashboard.NavigateToSection(hostingTypeSection);
            test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(500);
            test.Pages.SolutionDescription.LinkAddText(1000);
            test.Pages.HostingTypeSections.PublicCloud.ClickRequiresHscnN3ConnectivityCheckbox();

            if (hostingTypeSection != "Public cloud")
            {
                test.Pages.HostingTypeSections.PrivateCloud.EnterText(1000);
            }

            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Given(
            @"the user unchecks the HSCN/N3 connection checkbox on the (Public cloud|Private cloud|Hybrid|On premise) section")]
        public void GivenTheUserUnchecksTheHSCNNConnectionCheckboxOnThePublicCloudSection(string hostingTypeSection)
        {
            test.Pages.Dashboard.NavigateToSection(hostingTypeSection);
            test.Pages.HostingTypeSections.PublicCloud.ClickRequiresHscnN3ConnectivityCheckbox();
            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Given(@"I enter (.*) characters into the link field")]
        public void GivenIEnterCharactersIntoTheLinkField(int characters)
        {
            test.Pages.SolutionDescription.LinkAddText(characters);
        }
    }
}
