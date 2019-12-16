using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication
{
    [Binding]
    public sealed class SharedClientApplicationTypesSteps : TestBase
    {
        public SharedClientApplicationTypesSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the Supplier has entered (\d{3,4}) characters on the (.*) page in the (Browser based|Native mobile or tablet|Native desktop) section")]
        public void GivenTheSupplierHasEnteredText(int characters, string page, string section)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox(section);
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Dashboard.NavigateToSection(section, true);

            _test.pages.BrowserSubDashboard.OpenSection(page);

            _test.pages.HardwareRequirements.EnterText(characters);
        }

        [Given(@"each (Browser based|Native mobile or tablet|Native desktop) Sub-Section has a content validation status")]
        [Given(@"the .* Sub-Section in the (Browser based|Native mobile or tablet|Native desktop) section does not require Mandatory Data")]
        public void GivenTheSub_SectionDoesNotRequireMandatoryData(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.pages.ClientApplicationTypes.SelectCheckbox(section);
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            WhenHasNavigatedToTheSpecifiedClientApplicationSub_Form(section);
        }

        [When(@"the (Browser based|Native mobile or tablet|Native desktop) Client Application Sub-Form is presented")]
        public void WhenTheBrowserBasedClientApplicationSub_FormIsPresented(string sectionTitle)
        {
            _test.pages.Common.SubDashboardTitle().Should().BeEquivalentTo(sectionTitle);
        }

        [Then(@"the (.*) Sub-Section is marked as (Incomplete|Complete)")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsStatus(string sectionName, string status)
        {
            _test.pages.Dashboard.AssertSectionStatus(sectionName, status.ToUpper());
        }

        [Given(@"that (.*) has been completed in the (Browser based|Native mobile or tablet|Native desktop) section")]
        public void GivenThatSectionHasBeenCompleted(string sectionName, string section)
        {
            GivenTheSupplierHasEnteredText(100, sectionName, section);
            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.ClickSubDashboardBackLink();
        }

        [When(@"has navigated to the (Browser based|Native mobile or tablet|Native desktop) Client Application Sub-Form")]
        public void WhenHasNavigatedToTheSpecifiedClientApplicationSub_Form(string desiredSubForm)
        {
            _test.pages.Dashboard.NavigateToSection(desiredSubForm, true);
        }


    }
}
