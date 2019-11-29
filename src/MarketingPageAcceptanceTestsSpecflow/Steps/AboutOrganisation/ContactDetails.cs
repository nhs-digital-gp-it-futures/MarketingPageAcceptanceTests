using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutOrganisation
{
    [Binding]
    public sealed class ContactDetails
    {
        private UITest _test;
        private ScenarioContext _context;

        public ContactDetails(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"the User is able to manage the Contact Details Marketing Page Form Section")]
        public void ThenTheUserIsAbleToManageTheContactDetailsMarketingPageFormSection()
        {
            _test.pages.Dashboard.NavigateToSection("Contact details");
            _test.pages.ContactDetails.PageDisplayed().Should().BeTrue();
        }

    }
}
