using System;
using MarketingPageAcceptanceTests.Steps.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.PluginsOrExtensions
{
    [Binding]
    public class PluginOrExtension : TestBase
    {
        public PluginOrExtension(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that an answer is provided to the Plug-ins or extensions mandatory question")]
        public void GivenThatAnAnswerIsProvidedToThePlug_InsOrExtensionsMandatoryQuestion()
        {
            _test.Pages.Dashboard.NavigateToSection("Browser-based", true);
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Plug-ins or extensions required");

            var choice = new Random().Next() > int.MaxValue / 2 ? "Yes" : "No";

            _test.Pages.BrowserBasedSections.PluginsOrExtensions.SelectRadioButton(choice);
        }

        [Given(@"the Supplier has entered Plug-in or extensions description with character count (.*)")]
        public void GivenTheSupplierHasEnteredPlug_InOrExtensionsDescriptionThatDoesExceedTheMaximumCharacterCount(
            int count)
        {
            _test.Pages.BrowserBasedSections.PluginsOrExtensions.EnterPluginInformation(
                RandomInformation.RandomString(count));
        }
    }
}
