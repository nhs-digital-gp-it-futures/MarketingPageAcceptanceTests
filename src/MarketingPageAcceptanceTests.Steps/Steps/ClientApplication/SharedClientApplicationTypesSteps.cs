namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SharedClientApplicationTypesSteps : TestBase
    {
        public SharedClientApplicationTypesSteps(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [StepDefinition(
            @"the User has selected (Browser-based|Native mobile or tablet|Native desktop) Client Type as a Client Application Type")]
        public void WhenTheUserHasSelectedTheClientTypeAsAClientApplicationType(string clientType)
        {
            new SharedClientApplicationTypesSteps(test, context).SelectClientType(clientType);
        }

        [Then(
            @"the Authority User is able to access the (Browser-based|Native mobile or tablet|Native desktop) Client Type Type Sub-Dashboard")]
        public void ThenTheAuthorityUserIsAbleToAccessTheClientTypeTypeSub_Dashboard(string clientType)
        {
            test.Pages.Dashboard.NavigateToSection(clientType, true);
        }

        [Given(
            @"the Supplier has entered (\d{3,4}) characters on the (.*) page in the (Browser-based|Native mobile or tablet|Native desktop) section")]
        public void GivenTheSupplierHasEnteredText(int characters, string page, string section)
        {
            SelectClientType(section);

            test.Pages.Dashboard.NavigateToSection(section, true);

            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(page);

            test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }

        [Given(@"I enter (.*) characters into the second text field")]
        public void GivenIEnterCharactersIntoTheSecondTextField(int characters)
        {
            test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(characters, 1);
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
            test.Pages.Common.SubDashboardTitle().Should().ContainEquivalentOf(sectionTitle);
        }

        [Given(@"that (.*) has been completed in the (Browser-based|Native mobile or tablet|Native desktop) section")]
        public void GivenThatSectionHasBeenCompleted(string sectionName, string section)
        {
            GivenTheSupplierHasEnteredText(100, sectionName, section);
            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
            test.Pages.Common.ClickSubDashboardBackLink();
        }

        [StepDefinition(
            @"has navigated to the (Browser-based|Native mobile or tablet|Native desktop) Client Application Sub-Form")]
        public void WhenHasNavigatedToTheSpecifiedClientApplicationSub_Form(string desiredSubForm)
        {
            test.Pages.Dashboard.NavigateToSection(desiredSubForm, true);
        }

        [Given(@"validation has been triggered on (.*) section (.*)")]
        public void GivenValidationHasBeenTriggeredOnNativeMobileOrTabletSectionSupportedOperatingSystems(
            string subDashboard, string section)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
            test.Pages.Common.SectionSaveAndReturn();
        }

        [Given(@"a Supplier has saved all mandatory data on the (Browser-based|Native mobile or tablet|Native desktop) Client Application Type Sub-Sections")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_Sections(
            string clientApplicationType)
        {
            test.Solution.ClientApplication =
                ClientApplicationStringBuilder.GetClientAppString(null, clientApplicationType);

            test.Solution.Update(test.ConnectionString);
            test.Driver.Navigate().Refresh();
        }

        [Given(@"a Supplier has saved all mandatory data on the (Browser-based) Client Application Type Sub-Sections except for (Supported browsers|Plug-ins or extensions required|Connectivity and resolution|Mobile first approach)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(
            string clientApplicationType, string section)
        {
            test.Solution.ClientApplication =
                ClientApplicationStringBuilder.GetClientAppString(section, clientApplicationType);
            test.Solution.Update(test.ConnectionString);

            test.Driver.Navigate().Refresh();
        }

        [Given(@"a Supplier has saved all mandatory data on the (Native mobile or tablet) Client Application Type Sub-Sections except for (Supported operating systems|Memory and storage|Mobile first approach)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheNativeMobileClientApplicationTypeSub_SectionsExceptForX(
            string clientApplicationType, string section)
        {
            GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(
                clientApplicationType, section);
        }

        [Given(@"a Supplier has saved all mandatory data on the (Native desktop) Client Application Type Sub-Sections except for (Supported operating systems|Connectivity|Memory, storage, processing and resolution)")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheNativeDesktopClientApplicationTypeSub_SectionsExceptForX(
            string clientApplicationType, string section)
        {
            GivenASupplierHasSavedAllMandatoryDataOnTheClientApplicationTypeSub_SectionsExceptForX(
                clientApplicationType, section);
        }

        [Given(@"that (.*) has been completed for (Browser-based|Native mobile or tablet|Native desktop)")]
        public void GivenThatConnectionDetailsHasBeenCompletedForNativeDesktop(string subSection, string section)
        {
            test.Pages.Dashboard.NavigateToSection(section, true);
            test.Pages.Dashboard.NavigateToSection(subSection);
            switch (subSection)
            {
                case "Connectivity":
                    test.Pages.BrowserBasedSections.ConnectivityAndResolution.SelectRandomConnectionSpeed();
                    break;
                case "Memory, storage, processing and resolution":
                    test.Pages.NativeDesktopSections.MemoryAndStorage.CompleteAllFields();
                    break;
            }

            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
            test.Pages.Common.ClickSubDashboardBackLink();
        }

        public void SelectClientType(string clientType)
        {
            new CommonSteps(test, context).GivenTheUserHasSetBrowserBasedApplicationType(clientType);
        }
    }
}
