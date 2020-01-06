using System.Threading;
using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
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
            SelectClientType(section);

            _test.pages.Dashboard.NavigateToSection(section, true);

            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(page);

            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }

        [Given(@"I enter (.*) characters into the second text field")]
        public void GivenIEnterCharactersIntoTheSecondTextField(int characters)
        {
            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(characters, 1);
        }

        [Given(@"each (Browser based|Native mobile or tablet|Native desktop) Sub-Section has a content validation status")]
        [Given(@"the .* Sub-Section in the (Browser based|Native mobile or tablet|Native desktop) section does not require Mandatory Data")]
        public void GivenTheSub_SectionDoesNotRequireMandatoryData(string section)
        {
            SelectClientType(section);
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

        [Given(@"validation has been triggered on (.*) section (.*)")]
        public void GivenValidationHasBeenTriggeredOnNativeMobileOrTabletSectionSupportedOperatingSystems(string subDashboard, string section)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Given(@"the (Browser based|Native mobile or tablet|Native desktop) Client Application Type Section requires Mandatory Data")]
        public void GivenTheBrowserBasedClientApplicationTypeSectionRequiresMandatoryData(string section)
        {

        }

        [Given(@"a Supplier has saved all mandatory data on the (Browser based|Native mobile or tablet|Native desktop) Client Application Type Sub-Sections")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_Sections(string clientApplicationType)
        {
            _test.solutionDetail.ClientApplication = ClientApplicationStrings.GetClientAppString(null, clientApplicationType);

            SqlHelper.UpdateSolutionDetails(_test.solutionDetail, _test.connectionString);
            _test.driver.Navigate().Refresh();
        }

        [Given(@"a Supplier has saved all mandatory data on the (Browser based) Client Application Type Sub-Sections except for (Browsers supported|Plug-ins or extensions|Connectivity and resolution|Mobile first)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(string clientApplicationType, string section)
        {
            _test.solutionDetail.ClientApplication = ClientApplicationStrings.GetClientAppString(section, clientApplicationType);

            SqlHelper.UpdateSolutionDetails(_test.solutionDetail, _test.connectionString);
            Thread.Sleep(800);
            _test.driver.Navigate().Refresh();
        }

        [Given(@"a Supplier has saved all mandatory data on the (Native mobile or tablet) Client Application Type Sub-Sections except for (Supported operating systems|Memory and storage|Mobile first)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheNativeMobileClientApplicationTypeSub_SectionsExceptForX(string clientApplicationType, string section)
        {
            GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(clientApplicationType, section);
        }

        [Given(@"a Supplier has saved all mandatory data on the (Native desktop) Client Application Type Sub-Sections except for (Supported operating systems|Connection details|Memory, storage, processing and aspect ratio)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheNativeDesktopClientApplicationTypeSub_SectionsExceptForX(string clientApplicationType, string section)
        {
            GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(clientApplicationType, section);
        }

        private void SelectClientType(string clientType)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.pages.ClientApplicationTypes.SelectCheckbox(clientType);
            _test.pages.ClientApplicationTypes.SaveAndReturn();
        }
    }
}
