namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication
{
    using System.Collections.Generic;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class EditClientApplicationType : TestBase
    {
        private IList<string> allAppTypes;
        private IList<string> checkboxesSelected;

        public EditClientApplicationType(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a (Browser-based|Native mobile or tablet|Native desktop) Client Application Type is selected")]
        public void GivenThatAChosenClientApplicationTypeIsSelected(string clientApplicationType)
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            checkboxesSelected = new List<string> { clientApplicationType };
            test.Pages.ClientApplicationTypes.SelectCheckbox(clientApplicationType);
        }

        [Given(@"that a Client Application Type is not selected")]
        public void GivenThatAClientApplicationTypeIsNotSelected()
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            allAppTypes = test.Pages.ClientApplicationTypes.GetAppTypes();
            test.Pages.Common.ClickSectionBackLink();
            test.Pages.Dashboard.PageDisplayed();
        }

        [Given(@"a Supplier has saved any data on the Client Application Type Section")]
        public void GivenASupplierHasSavedAnyDataOnTheClientApplicationTypeSection()
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            test.Pages.ClientApplicationTypes.SelectRandomCheckbox();
            test.Pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given(@"validation has been triggered on Client application type")]
        public void GivenValidationHasBeenTriggeredOnClientApplicationType()
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            test.Pages.ClientApplicationTypes.SaveAndReturn();
            test.Pages.Common.ErrorMessageDisplayed();
        }

        [When(@"the section is saved")]
        public void WhenTheSectionIsSaved()
        {
            test.Pages.ClientApplicationTypes.SaveAndReturn();
            test.Pages.Dashboard.PageDisplayed();
        }

        [Then(@"the selected Client Application Type sub-category is available on the Marketing Page Form")]
        public void ThenTheSelectedClientApplicationTypeSub_CategoryIsAvailableOnTheMarketingPageForm()
        {
            // Check for link HREF containing the checkbox value from the sub dashboard
            test.Pages.Dashboard.SectionsAvailable(checkboxesSelected).Should().BeTrue();
        }

        [Then(@"there is a guidance message informing the User they need to select a Client Application Type")]
        public void ThenThereIsAGuidanceMessageInformingTheUserTheyNeedToSelectAClientApplicationType()
        {
            test.Pages.Dashboard.SectionsContainDefaultMessage(allAppTypes, "Select from client application types");
        }

        [Then(@"the Client Application Type Section is marked as Incomplete")]
        public void ThenTheClientApplicationTypeSectionIsMarkedAsIncomplete()
        {
            test.Pages.Dashboard.SectionIncompleteStatus("Client application type");
        }

        [Then(@"the Client Application Type Section is marked as Complete")]
        public void ThenTheClientApplicationTypeSectionIsMarkedAsComplete()
        {
            test.Pages.Dashboard.SectionCompleteStatus("Client application type");
        }
    }
}
