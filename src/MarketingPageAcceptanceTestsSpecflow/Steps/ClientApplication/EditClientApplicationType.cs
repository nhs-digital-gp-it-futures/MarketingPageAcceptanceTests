using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication
{
    [Binding]
    public class EditClientApplicationType
    {
        private UITest _test;
        private ScenarioContext _context;
        private IList<string> checkboxesSelected;
        private IList<string> allAppTypes;

        public EditClientApplicationType(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a Client Application Type is selected")]
        public void GivenThatAClientApplicationTypeIsSelected()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            checkboxesSelected = _test.pages.ClientApplicationTypes.SelectRandomCheckbox();
        }
        
        [Given(@"that a Client Application Type is not selected")]
        public void GivenThatAClientApplicationTypeIsNotSelected()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            allAppTypes = _test.pages.ClientApplicationTypes.GetAppTypes();
        }
        
        [Given(@"the Client Application Type Section requires Mandatory Data")]
        public void GivenTheClientApplicationTypeSectionRequiresMandatoryData()
        {
        }
        
        [Given(@"a Supplier has not saved any data on the Client Application Type Section")]
        public void GivenASupplierHasNotSavedAnyDataOnTheClientApplicationTypeSection()
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
        
        [Given(@"that a User has not provided at least one Client Application Type")]
        public void GivenThatAUserHasNotProvidedAtLeastOneClientApplicationType()
        {
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
            _test.pages.Dashboard.SectionIncomplete("Client application type");
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
