namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class DisplayClientApplicationType : TestBase
    {
        public DisplayClientApplicationType(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a Supplier has chosen to manage Client Application Type Information")]
        public static void GivenThatASupplierHasChosenToManageClientApplicationTypeInformation()
        {
        }

        [Given(@"the Section has a content validation status")]
        public void GivenTheSectionHasAContentValidationStatus()
        {
            test.Pages.Dashboard.AllSectionsContainStatus();
        }

        [Then(@"there is a list of Marketing Page Form Sections")]
        public void ThenThereIsAListOfMarketingPageFormSections()
        {
            test.Pages.Dashboard.PageDisplayed();
        }

        [Then(@"the Supplier is able to manage the Client Application Type Marketing Page Form Section")]
        public void ThenTheSupplierIsAbleToManageTheClientApplicationTypeMarketingPageFormSection()
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
        }
    }
}
