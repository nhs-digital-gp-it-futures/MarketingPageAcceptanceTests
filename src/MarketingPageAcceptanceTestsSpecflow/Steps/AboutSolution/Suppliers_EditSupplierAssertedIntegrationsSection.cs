using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutSolution
{
    [Binding]
    public class Suppliers_EditSupplierAssertedIntegrationsSection : TestBase
    {
        public Suppliers_EditSupplierAssertedIntegrationsSection(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"the User has entered (\d{3,4}) characters on the Catalogue Solution integrations page in the (Integrations) section")]
        public void GivenTheUserHasEnteredCharactersOnTheCatalogueSolutionIntegrationsPageInTheIntegrationsSection(int characters, string section)
        {
            _test.pages.Dashboard.NavigateToSection(section);
            _test.pages.SolutionDescription.LinkAddText(characters);
        }

        [Given(@"a User has saved any data on the Integrations page")]
        public void GivenAUserHasSavedAnyDataOnTheIntegrationsPage()
        {
            GivenTheUserHasEnteredCharactersOnTheCatalogueSolutionIntegrationsPageInTheIntegrationsSection(100, "Integrations");
            _test.pages.Common.SectionSaveAndReturn();
        }

    }
}
