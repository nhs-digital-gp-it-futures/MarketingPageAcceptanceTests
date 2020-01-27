using System;
using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow
{
    [Binding]
    public class SharedHostingTypeSteps : TestBase
    {
        public SharedHostingTypeSteps(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"the User has entered (\d{3,4}) characters on the (.*) page in the (Public cloud|Private cloud|Hybrid|On premise|Roadmap|About supplier) section")]
        public void GivenTheSupplierHasEnteredText(int characters, string page, string section)
        {
            _test.pages.Dashboard.NavigateToSection(section);

            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }

        [Given(@"the (Public cloud|Private cloud|Hybrid|On premise|Roadmap|About supplier) section does not require Mandatory Data")]
        public void GivenTheHostingTypeSectionDoesNotRequireMandatoryData(string hostingTypeSection)
        {

        }

        [Given(@"a User has not saved any data on the (Public cloud|Private cloud|Hybrid|On premise) section")]
        public void GivenAUserHasNotSavedAnyDataOnTheHostingTypeSection(string hostingTypeSection)
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
