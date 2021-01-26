namespace MarketingPageAcceptanceTests.Steps.Steps.AboutSolution
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class Suppliers_EditSupplierAssertedIntegrationsSection : TestBase
    {
        public Suppliers_EditSupplierAssertedIntegrationsSection(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"the (?:Supplier|Authority user) has entered (\d{3,4}) characters on the Catalogue Solution integrations page in the (Integrations) section")]
        public void GivenTheUserHasEnteredCharactersOnTheCatalogueSolutionIntegrationsPageInTheIntegrationsSection(
            int characters,
            string section)
        {
            test.Pages.Dashboard.NavigateToSection(section);
            test.Pages.SolutionDescription.LinkAddText(characters);
        }

        [Given(@"a (?:Supplier|Authority User) has saved any data on the Integrations page")]
        public void GivenAUserHasSavedAnyDataOnTheIntegrationsPage()
        {
            GivenTheUserHasEnteredCharactersOnTheCatalogueSolutionIntegrationsPageInTheIntegrationsSection(
                100,
                "Integrations");
            test.Pages.Common.SectionSaveAndReturn();
        }
    }
}
