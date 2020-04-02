using FluentAssertions;
using MarketingPageAcceptanceTests.StepSetup.Utils;
using MarketingPageAcceptanceTests.TestData.Solutions;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication
{
    [Binding]
    public sealed class SharedClientApplicationTypesSteps : TestBase
    {
        public SharedClientApplicationTypesSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [StepDefinition(
            @"the User has selected (Browser-based|Native mobile or tablet|Native desktop) Client Type as a Client Application Type")]
        public void WhenTheUserHasSelectedTheClientTypeAsAClientApplicationType(string clientType)
        {
            new SharedClientApplicationTypesSteps(_test, _context).SelectClientType(clientType);
        }

        [Then(
            @"the Authority User is able to access the (Browser-based|Native mobile or tablet|Native desktop) Client Type Type Sub-Dashboard")]
        public void ThenTheAuthorityUserIsAbleToAccessTheClientTypeTypeSub_Dashboard(string clientType)
        {
            _test.Pages.Dashboard.NavigateToSection(clientType, true);
        }

        [Given(
            @"the Supplier has entered (\d{3,4}) characters on the (.*) page in the (Browser-based|Native mobile or tablet|Native desktop) section")]
        public void GivenTheSupplierHasEnteredText(int characters, string page, string section)
        {
            SelectClientType(section);

            _test.Pages.Dashboard.NavigateToSection(section, true);

            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(page);

            _test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }

        [Given(@"I enter (.*) characters into the second text field")]
        public void GivenIEnterCharactersIntoTheSecondTextField(int characters)
        {
            _test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(characters, 1);
        }

        [Given(
            @"each (Browser-based|Native mobile or tablet|Native desktop) Sub-Section has a content validation status")]
        [Given(
            @"the .* Sub-Section in the (Browser-based|Native mobile or tablet|Native desktop) section does not require Mandatory Data")]
        public void GivenTheSub_SectionDoesNotRequireMandatoryData(string section)
        {
            SelectClientType(section);
            WhenHasNavigatedToTheSpecifiedClientApplicationSub_Form(section);
        }

        [When(@"the (Browser-based|Native mobile or tablet|Native desktop) Client Application Sub-Form is presented")]
        public void WhenTheBrowserBasedClientApplicationSub_FormIsPresented(string sectionTitle)
        {
            _test.Pages.Common.SubDashboardTitle().Should().ContainEquivalentOf(sectionTitle);
        }

        [Given(@"that (.*) has been completed in the (Browser-based|Native mobile or tablet|Native desktop) section")]
        public void GivenThatSectionHasBeenCompleted(string sectionName, string section)
        {
            GivenTheSupplierHasEnteredText(100, sectionName, section);
            _test.Pages.Common.SectionSaveAndReturn();
            _test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
            _test.Pages.Common.ClickSubDashboardBackLink();
        }

        [StepDefinition(
            @"has navigated to the (Browser-based|Native mobile or tablet|Native desktop) Client Application Sub-Form")]
        public void WhenHasNavigatedToTheSpecifiedClientApplicationSub_Form(string desiredSubForm)
        {
            _test.Pages.Dashboard.NavigateToSection(desiredSubForm, true);
        }

        [Given(@"validation has been triggered on (.*) section (.*)")]
        public void GivenValidationHasBeenTriggeredOnNativeMobileOrTabletSectionSupportedOperatingSystems(
            string subDashboard, string section)
        {
            _test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
            _test.Pages.Common.SectionSaveAndReturn();
        }

        [Given(
            @"the (Browser-based|Native mobile or tablet|Native desktop) Client Application Type Section requires Mandatory Data")]
        public void GivenTheBrowserBasedClientApplicationTypeSectionRequiresMandatoryData(string section)
        {
        }

        [Given(
            @"a Supplier has saved all mandatory data on the (Browser-based|Native mobile or tablet|Native desktop) Client Application Type Sub-Sections")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_Sections(
            string clientApplicationType)
        {
            _test.solutionDetail.ClientApplication =
                ClientApplicationStringBuilder.GetClientAppString(null, clientApplicationType);

            _test.solutionDetail.Update(_test.ConnectionString);
            _test.Driver.Navigate().Refresh();
        }

        [Given(
            @"a Supplier has saved all mandatory data on the (Browser-based) Client Application Type Sub-Sections except for (Supported browsers|Plug-ins or extensions required|Connectivity and resolution|Mobile first approach)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(
            string clientApplicationType, string section)
        {
            _test.solutionDetail.ClientApplication =
                ClientApplicationStringBuilder.GetClientAppString(section, clientApplicationType);
            _test.solutionDetail.Update(_test.ConnectionString);

            _test.Driver.Navigate().Refresh();
        }

        [Given(
            @"a Supplier has saved all mandatory data on the (Native mobile or tablet) Client Application Type Sub-Sections except for (Supported operating systems|Memory and storage|Mobile first approach)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheNativeMobileClientApplicationTypeSub_SectionsExceptForX(
            string clientApplicationType, string section)
        {
            GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(
                clientApplicationType, section);
        }

        [Given(
            @"a Supplier has saved all mandatory data on the (Native desktop) Client Application Type Sub-Sections except for (Supported operating systems|Connectivity|Memory, storage, processing and resolution)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheNativeDesktopClientApplicationTypeSub_SectionsExceptForX(
            string clientApplicationType, string section)
        {
            GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(
                clientApplicationType, section);
        }

        [Given(@"that (.*) has been completed for (Browser-based|Native mobile or tablet|Native desktop)")]
        public void GivenThatConnectionDetailsHasBeenCompletedForNativeDesktop(string subSection, string section)
        {
            _test.Pages.Dashboard.NavigateToSection(section, true);
            _test.Pages.Dashboard.NavigateToSection(subSection);
            switch (subSection)
            {
                case "Connectivity":
                    _test.Pages.BrowserBasedSections.ConnectivityAndResolution.SelectRandomConnectionSpeed();
                    break;
                case "Memory, storage, processing and resolution":
                    _test.Pages.NativeDesktopSections.MemoryAndStorage.CompleteAllFields();
                    break;
            }

            _test.Pages.Common.SectionSaveAndReturn();
            _test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
            _test.Pages.Common.ClickSubDashboardBackLink();
        }

        public void SelectClientType(string clientType)
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.Pages.ClientApplicationTypes.SelectCheckbox(clientType);
            _test.Pages.ClientApplicationTypes.SaveAndReturn();
        }
    }
}