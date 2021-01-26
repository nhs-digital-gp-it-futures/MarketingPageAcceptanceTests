namespace MarketingPageAcceptanceTests.Steps.Steps
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CommonSteps : TestBase
    {
        public CommonSteps(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"a .* has not saved any data in any field within the Sub-Section")]
        [Given(@"a User has not saved any data on the .* section")]
        [Given(@"a Supplier has not saved any data on the Client Application Type section")]
        [Then(@"the Section is not saved")]
        [Given(@"a Supplier has not saved Mandatory data on all the Browser-based Client Application Type Sub-Sections")]
        [Then(@"the Section is not saved because it is mandatory")]
        [Given(@"the (?:Public cloud|Private cloud|Hybrid|On premise) section does not require Mandatory Data")]
        [Given(@"the (?:Roadmap|Integrations|Implementation timescales) section does not require Mandatory Data")]
        [Given(@"a (?:.*) attachment has not been provided for the Solution")]
        [Given(@"that a (?:Supplier|Authority User) has chosen to manage the .* Client Application Type Section")]
        [Given(@"the (?:Browser-based|Native mobile or tablet|Native desktop) Client Application Type Section requires Mandatory Data")]
        [Given(@"the Contact Details Section has no Mandatory Data")]
        [Then(@"the Section is not saved because it is mandatory to answer both questions")]
        [Given(@"that a Supplier has chosen to manage Client Application Type Information")]
        [Given(@"the Client Application Type Section requires Mandatory Data")]
        [Then(@"no Client Application Type sub-category is available on the Marketing Page Form")]
        [Given(@"that a Supplier has not provided all mandatory data on the Marketing Page")]
        [Then(@"the User will be informed that Submission was successful")]
        [Given(@"that a (?:Supplier|User) has chosen to manage Marketing Page Information")]
        [Given(@"the Solution Description Section requires Mandatory Data")]
        public static void NoAction()
        {
        }

        [Given(@"the user has navigated to the (Supplier|Authority) pages")]
        public void GivenTheUserHasNavigatedToTheSupplierPages(string userType)
        {
            test.SetUrl(test.Solution.Id, userType);
            test.GoToUrl();
        }

        [Given(@"the user has set (.*) application type")]
        public void GivenTheUserHasSetBrowserBasedApplicationType(string clientType)
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            test.Pages.ClientApplicationTypes.SelectCheckbox(clientType);
            test.Pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given(@"validation has been triggered on (.*) section")]
        public void GivenValidationHasBeenTriggeredOnSection(string section)
        {
            test.Pages.Dashboard.NavigateToSection(section);
            test.Pages.SolutionDescription.SaveAndReturn();
            test.Pages.Common.ErrorMessageDisplayed();
        }

        [When(@"the User selects an error link in the Error Summary")]
        public void WhenTheUserSelectsAnErrorLinkInTheErrorSummary()
        {
            test.ExpectedSectionLinkInErrorMessage = test.Pages.Common.ClickOnErrorLink();
        }

        [When("the Marketing Page Form is presented")]
        public void MarketingPageFormPresented()
        {
            test.Pages.Dashboard.PageDisplayed();
        }

        [Then(@"(.*) will be presented in the (.*) section on the Preview of the Marketing Page")]
        public void ThenSectionWillBePresentedOnThePreviewOfTheMarketingPage(string section, string subSection)
        {
            test.Pages.PreviewPage.ExpandSection(subSection);
            test.Pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(
            string section, string subDashboard)
        {
            test.Pages.PreviewPage.ExpandSection(subDashboard);
            test.Pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will not be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillNotBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(
            string section, string subDashboard)
        {
            test.Pages.PreviewPage.ExpandSection(subDashboard);
            test.Pages.PreviewPage.SectionNotDisplayed(section);
        }

        [When(@"the User exits the page")]
        public void WhenTheUserExitsThePage()
        {
            test.Pages.Common.ClickSectionBackLink();
        }

        [When(@"a User saves the page")]
        [StepDefinition(@"the User attempts to save")]
        public void WhenTheUserAttemptsToSave()
        {
            test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the (.*) content validation status is displayed")]
        public void ThenTheClientApplicationTypeContentValidationStatusIsDisplayed(string section)
        {
            test.Pages.Dashboard.SectionHasStatus(section).Should().BeTrue();
        }

        [Then(@"the (?:Supplier|User) is able to manage the (.*) Marketing Page (Dashboard|Form Section)")]
        public void ThenTheSupplierIsAbleToManageTheMarketingPageFormSection(
            string section,
            string pageType)
        {
            test.Pages.Dashboard.NavigateToSection(section, pageType == "Dashboard");
        }

        [Then(@"the (.*) (?:Sub-Section|section) is marked as (Incomplete|Complete)")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsStatus(
            string sectionName,
            string status)
        {
            test.Pages.Dashboard.AssertSectionStatus(sectionName, status.ToUpper());
        }

        [Given(@"the User refreshes the page")]
        public void WhenTheUserRerfreshesThePage()
        {
            test.Driver.Navigate().Refresh();
            MarketingPageFormPresented();
        }

        [Given(
            @"the (Supplier|Authority User) has entered (\d{3,4}) characters on the (?:.*) page in the (Public cloud|Private cloud|Hybrid|On premise) section")]
        [Given(
            @"the (Supplier|Authority User) has entered (\d{3,4}) characters on the (?:.*) page in the (Roadmap|About supplier|Implementation timescales) section")]
        public void GivenTheSupplierHasEnteredText(string userType, int characters, string section)
        {
            test.SetUrl(test.Solution.Id, userType);
            test.GoToUrl();

            test.Pages.Dashboard.NavigateToSection(section);

            test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }
    }
}
