using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps
{
    [Binding]
    public sealed class CommonSteps : TestBase
    {
        public CommonSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the user has navigated to the (Supplier|Authority) pages")]
        public void GivenTheUserHasNavigatedToTheSupplierPages(string userType)
        {
            _test.SetUrl(_test.solution.Id, userType);
            _test.GoToUrl();
        }


        [Given(@"the user has set (.*) application type")]
        public void GivenTheUserHasSetBrowserBasedApplicationType(string clientType)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox(clientType);
            _test.pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given(@"validation has been triggered on (.*) section")]
        public void GivenValidationHasBeenTriggeredOnSection(string section)
        {
            _test.pages.Dashboard.NavigateToSection(section);
            _test.pages.SolutionDescription.SaveAndReturn();
            _test.pages.Common.ErrorMessageDisplayed();
        }

        [When(@"the User selects an error link in the Error Summary")]
        public void WhenTheUserSelectsAnErrorLinkInTheErrorSummary()
        {
            _test.ExpectedSectionLinkInErrorMessage = _test.pages.Common.ClickOnErrorLink();
        }

        [When("the Marketing Page Form is presented")]
        public void MarketingPageFormPresented()
        {
            _test.pages.Dashboard.PageDisplayed();
        }

        [Then(@"(.*) will be presented in the (.*) section on the Preview of the Marketing Page")]
        public void ThenSectionWillBePresentedOnThePreviewOfTheMarketingPage(string section, string subSection)
        {
            _test.pages.PreviewPage.ExpandSection(subSection);
            _test.pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(string section, string subDashboard)
        {
            _test.pages.PreviewPage.ExpandSection(subDashboard);
            _test.pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will not be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillNotBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(string section, string subDashboard)
        {
            _test.pages.PreviewPage.ExpandSection(subDashboard);
            _test.pages.PreviewPage.SectionNotDisplayed(section);
        }

        [When(@"the User exits the page")]
        public void WhenTheUserExitsThePage()
        {
            _test.pages.Common.ClickSectionBackLink();
        }

        [When(@"a User saves the page")]
        [StepDefinition(@"the User attempts to save")]
        public void WhenTheUserAttemptsToSave()
        {
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the (.*) content validation status is displayed")]
        public void ThenTheClientApplicationTypeContentValidationStatusIsDisplayed(string section)
        {
            _test.pages.Dashboard.SectionHasStatus(section).Should().BeTrue();
        }

        [Then(@"the (Supplier|User) is able to manage the (.*) Marketing Page (Dashboard|Form Section)")]
        public void ThenTheSupplierIsAbleToManageTheMarketingPageFormSection(string user, string section, string pageType)
        {
            _test.pages.Dashboard.NavigateToSection(section, pageType == "Dashboard");
        }

        [Then(@"the (.*) (Sub-Section|section) is marked as (Incomplete|Complete)")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsStatus(string sectionName, string sectionOrSubSection, string status)
        {
            _test.pages.Dashboard.AssertSectionStatus(sectionName, status.ToUpper());
        }

        [Given(@"the (Public cloud|Private cloud|Hybrid|On premise) section does not require Mandatory Data")]
        [Given(@"the (Roadmap|Integrations|Implementation timescales) section does not require Mandatory Data")]
        public void GivenTheSectionDoesNotRequireMandatoryData(string section)
        {
            //add any new pages as necessary
            //can't wildcard it as some pages need to do something
        }

        [Given(@"a .* has not saved any data in any field within the Sub-Section")]
        [Given(@"a User has not saved any data on the .* section")]
        [Given(@"a Supplier has not saved any data on the Client Application Type section")]
        public void GivenAUserHasNotSavedAnyDataOnTheSection()
        {
        }

        [Given(@"the User refreshes the page")]
        public void WhenTheUserRerfreshesThePage()
        {
            _test.driver.Navigate().Refresh();
            MarketingPageFormPresented();
        }

        [Given(@"the (Supplier|Authority User) has entered (\d{3,4}) characters on the (.*) page in the (Public cloud|Private cloud|Hybrid|On premise) section")]
        [Given(@"the (Supplier|Authority User) has entered (\d{3,4}) characters on the (.*) page in the (Roadmap|About supplier|Implementation timescales) section")]
        public void GivenTheSupplierHasEnteredText(string userType, int characters, string page, string section)
        {
            _test.SetUrl(_test.solution.Id, userType);
            _test.GoToUrl();

            _test.pages.Dashboard.NavigateToSection(section);

            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }

        [Given(@"a (.*) attachment has not been provided for the Solution")]
        public void GivenARoadmapAttachmentHasNotBeenProvidedForTheSolution(string documentType)
        {
        }

        [Given(@"(a|an) (Roadmap|NHS Assured Integrations|Authority Provided Data Document) attachment has been provided for the Solution")]
        public async Task GivenARoadmapAttachmentHasBeenProvidedForTheSolution(string s1, string documentType)
        {
            string fileName;
            if(documentType.Equals("NHS Assured Integrations", StringComparison.OrdinalIgnoreCase))
            {
                documentType = "Integrations";
            }
            fileName = documentType.ToLower() + ".pdf";
            var path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", fileName);
            await _test.azureBlobStorage.InsertFileToStorage(_test.defaultAzureBlobStorageContainerName, _test.solution.Id, fileName, path);

        }




    }
}
