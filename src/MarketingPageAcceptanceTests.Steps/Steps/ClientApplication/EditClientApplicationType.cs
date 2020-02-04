using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps.ClientApplication
{
    [Binding]
    public class EditClientApplicationType : TestBase
    {
        private IList<string> checkboxesSelected;
        private IList<string> allAppTypes;

        public EditClientApplicationType(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a (Browser based|Native mobile or tablet|Native desktop) Client Application Type is selected")]
        public void GivenThatAChosenClientApplicationTypeIsSelected(string clientApplicationType)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            checkboxesSelected = new List<string>() { clientApplicationType };
            _test.pages.ClientApplicationTypes.SelectCheckbox(clientApplicationType);
        }

        [Given(@"that a Client Application Type is not selected")]
        public void GivenThatAClientApplicationTypeIsNotSelected()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            allAppTypes = _test.pages.ClientApplicationTypes.GetAppTypes();
            _test.pages.Common.ClickSectionBackLink();
            _test.pages.Dashboard.PageDisplayed();
        }

        [Given(@"the Client Application Type Section requires Mandatory Data")]
        public void GivenTheClientApplicationTypeSectionRequiresMandatoryData()
        {
        }

        [Given(@"a Supplier has saved any data on the Client Application Type Section")]
        public void GivenASupplierHasSavedAnyDataOnTheClientApplicationTypeSection()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.pages.ClientApplicationTypes.SelectRandomCheckbox();
            _test.pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given(@"validation has been triggered on Client application type")]
        public void GivenValidationHasBeenTriggeredOnClientApplicationType()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Common.ErrorMessageDisplayed();
        }


        [When(@"the section is saved")]
        public void WhenTheSectionIsSaved()
        {
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Dashboard.PageDisplayed();
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
            _test.pages.Dashboard.SectionsAvailable(checkboxesSelected).Should().BeTrue();
        }

        [Then(@"no Client Application Type sub-category is available on the Marketing Page Form")]
        public void ThenNoClientApplicationTypeSub_CategoryIsAvailableOnTheMarketingPageForm()
        {
        }

        [Then(@"there is a guidance message informing the User they need to select a Client Application Type")]
        public void ThenThereIsAGuidanceMessageInformingTheUserTheyNeedToSelectAClientApplicationType()
        {
            _test.pages.Dashboard.SectionsContainDefaultMessage(allAppTypes, "Select from client application types");
        }

        [Then(@"the Client Application Type Section is marked as Incomplete")]
        public void ThenTheClientApplicationTypeSectionIsMarkedAsIncomplete()
        {
            _test.pages.Dashboard.SectionIncompleteStatus("Client application type");
        }

        [Then(@"the Client Application Type Section is marked as Complete")]
        public void ThenTheClientApplicationTypeSectionIsMarkedAsComplete()
        {
            _test.pages.Dashboard.SectionCompleteStatus("Client application type");
        }

        [Then(@"the User will be informed that they need to select a Client Application Type before they can submit")]
        public void ThenTheUserWillBeInformedThatTheyNeedToSelectAClientApplicationTypeBeforeTheyCanSubmit()
        {
            _context.Pending();
        }
    }
}
