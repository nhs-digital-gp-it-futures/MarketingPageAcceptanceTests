using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.AboutSolution
{
    [Binding]
    public class Suppliers_EditSupplierAssertedIntegrationsSection : TestBase
    {
        public Suppliers_EditSupplierAssertedIntegrationsSection(UITest test, ScenarioContext context) : base(test,
            context)
        {
        }

        [Given(
            @"the (Supplier|Authority user) has entered (\d{3,4}) characters on the Catalogue Solution integrations page in the (Integrations) section")]
        public void GivenTheUserHasEnteredCharactersOnTheCatalogueSolutionIntegrationsPageInTheIntegrationsSection(
            string userType, int characters, string section)
        {
            _test.Pages.Dashboard.NavigateToSection(section);
            _test.Pages.SolutionDescription.LinkAddText(characters);
        }

        [Given(@"a (Supplier|Authority User) has saved any data on the Integrations page")]
        public void GivenAUserHasSavedAnyDataOnTheIntegrationsPage(string userType)
        {
            GivenTheUserHasEnteredCharactersOnTheCatalogueSolutionIntegrationsPageInTheIntegrationsSection(userType,
                100, "Integrations");
            _test.Pages.Common.SectionSaveAndReturn();
        }
    }
}