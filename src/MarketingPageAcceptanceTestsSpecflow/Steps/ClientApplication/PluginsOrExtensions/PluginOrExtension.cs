using System;
using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTestsSpecflow.Utils;
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
        public void GivenThatAnAnswerIsProvidedToThePlug_InsOrExtensionsMandatoryQuestion()
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection("Plug-ins or extensions");

            var choice = new Random().Next() > (int.MaxValue / 2) ? "Yes" : "No";

            _test.pages.PluginsOrExtensions.SelectRadioButton(choice);
        }

        [Given(@"the Supplier has entered Plug-in or extensions description with character count (.*)")]
        public void GivenTheSupplierHasEnteredPlug_InOrExtensionsDescriptionThatDoesExceedTheMaximumCharacterCount(int count)
        {
            _test.pages.PluginsOrExtensions.EnterPluginInformation(RandomInformation.RandomString(count));
        }
    }
}
