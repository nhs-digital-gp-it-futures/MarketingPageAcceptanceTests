namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.PluginsOrExtensions
{
    using System;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using TechTalk.SpecFlow;

    [Binding]
    public class PluginOrExtension : TestBase
    {
        public PluginOrExtension(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that an answer is provided to the Plug-ins or extensions mandatory question")]
        public void GivenThatAnAnswerIsProvidedToThePlug_InsOrExtensionsMandatoryQuestion()
        {
            test.Pages.Dashboard.NavigateToSection("Browser-based", true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Plug-ins or extensions required");

            var choice = new Random().Next() > int.MaxValue / 2 ? "Yes" : "No";

            test.Pages.BrowserBasedSections.PluginsOrExtensions.SelectRadioButton(choice);
        }

        [Given(@"the Supplier has entered Plug-in or extensions description with character count (.*)")]
        public void GivenTheSupplierHasEnteredPlug_InOrExtensionsDescriptionThatDoesExceedTheMaximumCharacterCount(
            int count)
        {
            test.Pages.BrowserBasedSections.PluginsOrExtensions.EnterPluginInformation(
                RandomInformation.RandomString(count));
        }
    }
}
