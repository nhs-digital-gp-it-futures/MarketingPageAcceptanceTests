using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.PluginsOrExtensions
{
    [Binding]
    public class PluginOrExtension
    {
        private UITest _test;
        private ScenarioContext _context;

        public PluginOrExtension(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that an answer is provided to the Plug-ins or extensions mandatory question")]
        public void GivenThatAnAnswerIsProvidedToThePlug_InsOrExtensionsMandatoryQuestion(string section)
        {   
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);

            var choice = new Random().Next() > (int.MaxValue / 2) ? "Yes" : "No";

            _test.pages.PluginsOrExtensions.SelectRadioButton(choice);
        }

        [Given(@"the Supplier has entered text")]
        public void GivenTheSupplierHasEnteredText()
        {
            _test.pages.PluginsOrExtensions.EnterPluginInformation(RandomInformation.RandomInformationText(), true);
        }
    }
}
