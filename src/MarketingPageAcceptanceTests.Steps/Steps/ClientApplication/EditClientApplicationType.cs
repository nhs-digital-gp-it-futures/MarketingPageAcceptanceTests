using System.Collections.Generic;
using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication
{
    [Binding]
    public class EditClientApplicationType : TestBase
    {
        private IList<string> allAppTypes;
        private IList<string> checkboxesSelected;

        public EditClientApplicationType(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a (Browser-based|Native mobile or tablet|Native desktop) Client Application Type is selected")]
        public void GivenThatAChosenClientApplicationTypeIsSelected(string clientApplicationType)
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            checkboxesSelected = new List<string> {clientApplicationType};
            _test.Pages.ClientApplicationTypes.SelectCheckbox(clientApplicationType);
        }

        [Given(@"that a Client Application Type is not selected")]
        public void GivenThatAClientApplicationTypeIsNotSelected()
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            allAppTypes = _test.Pages.ClientApplicationTypes.GetAppTypes();
            _test.Pages.Common.ClickSectionBackLink();
            _test.Pages.Dashboard.PageDisplayed();
        }

        [Given(@"the Client Application Type Section requires Mandatory Data")]
        public void GivenTheClientApplicationTypeSectionRequiresMandatoryData()
        {
        }

        [Given(@"a Supplier has saved any data on the Client Application Type Section")]
        public void GivenASupplierHasSavedAnyDataOnTheClientApplicationTypeSection()
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.Pages.ClientApplicationTypes.SelectRandomCheckbox();
            _test.Pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given(@"validation has been triggered on Client application type")]
        public void GivenValidationHasBeenTriggeredOnClientApplicationType()
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.Pages.ClientApplicationTypes.SaveAndReturn();
            _test.Pages.Common.ErrorMessageDisplayed();
        }


        [When(@"the section is saved")]
        public void WhenTheSectionIsSaved()
        {
            _test.Pages.ClientApplicationTypes.SaveAndReturn();
            _test.Pages.Dashboard.PageDisplayed();
        }

        [When(@"the User submits their Marketing Page")]
        public void WhenTheUserSubmitsTheirMarketingPage()
        {
            _context.Pending();
        }

        [Then(@"the selected Client Application Type sub-category is available on the Marketing Page Form")]
        public void ThenTheSelectedClientApplicationTypeSub_CategoryIsAvailableOnTheMarketingPageForm()
        {
            // Check for link HREF containing the checkbox value from the sub dashboard
            _test.Pages.Dashboard.SectionsAvailable(checkboxesSelected).Should().BeTrue();
        }

        [Then(@"no Client Application Type sub-category is available on the Marketing Page Form")]
        public void ThenNoClientApplicationTypeSub_CategoryIsAvailableOnTheMarketingPageForm()
        {
        }

        [Then(@"there is a guidance message informing the User they need to select a Client Application Type")]
        public void ThenThereIsAGuidanceMessageInformingTheUserTheyNeedToSelectAClientApplicationType()
        {
            _test.Pages.Dashboard.SectionsContainDefaultMessage(allAppTypes, "Select from client application types");
        }

        [Then(@"the Client Application Type Section is marked as Incomplete")]
        public void ThenTheClientApplicationTypeSectionIsMarkedAsIncomplete()
        {
            _test.Pages.Dashboard.SectionIncompleteStatus("Client application type");
        }

        [Then(@"the Client Application Type Section is marked as Complete")]
        public void ThenTheClientApplicationTypeSectionIsMarkedAsComplete()
        {
            _test.Pages.Dashboard.SectionCompleteStatus("Client application type");
        }

        [Then(@"the User will be informed that they need to select a Client Application Type before they can submit")]
        public void ThenTheUserWillBeInformedThatTheyNeedToSelectAClientApplicationTypeBeforeTheyCanSubmit()
        {
            _context.Pending();
        }
    }
}