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

        [Given(@"that an answer is provided to the (.*) mandatory question")]
        public void GivenThatAnAnswerIsProvidedToThePlug_InsOrExtensionsMandatoryQuestion(string section)
        {   
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);

            var choice = new Random().Next() > (int.MaxValue / 2) ? "Yes" : "No";

            _test.pages.PluginsOrExtensions.SelectRadioButton(choice);
        }

        [Given(@"that an answer has not been provided to the (.*) mandatory question")]
        public void GivenThatAnAnswerHasNotBeenProvidedToThePlug_InsOrExtensionsMandatoryQuestion(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);
        }


        [Given(@"the Supplier has entered text")]
        public void GivenTheSupplierHasEnteredText()
        {
            _test.pages.PluginsOrExtensions.EnterPluginInformation(RandomInformation.RandomInformationText(), true);
        }

        [Given(@"validation has been triggered on Browser based section (.*)")]
        public void GivenValidationHasBeenTriggeredOnSection(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Given(@"that a User has not provided any mandatory data for (.*)")]
        public void GivenThatAUserHasNotProvidedAnyMandatoryDataForSection(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);
        }

    }
}
