using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps
{
    [Binding]
    public class SharedHostingTypeSteps : TestBase
    {
        public SharedHostingTypeSteps(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Then(@"The (Public cloud|Private cloud|Hybrid|On premise) section (contains|does not contain) This Solution requires a HSCN/N3 connection on the preview of the marketing page")]
        public void ThenThePublicCloudSectionContainsThisSolutionRequiresAHSCNNConnectionOnThePreviewOfTheMarketingPage(string hostingTypeSection, string assertionText)
        {
            _test.pages.PreviewPage.IsRequiresHscnDisplayed(hostingTypeSection).Should().Be(assertionText == "contains");
        }

        [Given(@"that (Public cloud|Private cloud|Hybrid|On premise) has been completed in the Hosting type section")]
        public void GivenThatPublicCloudHasBeenCompletedInTheHostingTypeSection(string hostingTypeSection)
        {
            _test.pages.Dashboard.NavigateToSection(hostingTypeSection);
            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(500, 0);
            _test.pages.SolutionDescription.LinkAddText(1000);
            _test.pages.HostingTypeSections.PublicCloud.ClickRequiresHscnN3ConnectivityCheckbox();
            if (hostingTypeSection != "Public cloud")
            {
                _test.pages.HostingTypeSections.PrivateCloud.EnterText(1000);
            }
            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Given(@"the user unchecks the HSCN/N3 connection checkbox on the (Public cloud|Private cloud|Hybrid|On premise) section")]
        public void GivenTheUserUnchecksTheHSCNNConnectionCheckboxOnThePublicCloudSection(string hostingTypeSection)
        {
            _test.pages.Dashboard.NavigateToSection(hostingTypeSection);
            _test.pages.HostingTypeSections.PublicCloud.ClickRequiresHscnN3ConnectivityCheckbox();
            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Given(@"I enter (.*) characters into the link field")]
        public void GivenIEnterCharactersIntoTheLinkField(int characters)
        {
            _test.pages.SolutionDescription.LinkAddText(characters);
        }
    }
}
