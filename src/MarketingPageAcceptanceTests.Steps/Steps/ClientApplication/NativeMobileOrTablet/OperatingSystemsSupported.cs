using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps.ClientApplication.NativeMobileOrTablet
{
    [Binding]
    public class OperatingSystemsSupported : TestBase
    {
        public OperatingSystemsSupported(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a User has provided a value for the Mandatory Information for (Supported operating systems) section on (Native mobile or tablet) sub dashboard")]
        public void GivenThatAUserHasProvidedAValueForTheMandatoryInformation(string section, string subDashboard)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);

            _test.pages.NativeMobileSections.OperatingSystems.SelectCheckboxes(1);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Given(@"that an answer has not been provided to the mandatory question for (.*) section on (.*) sub dashboard")]
        public void GivenThatAnAnswerHasNotBeenProvidedToTheMandatoryQuestion(string section, string subDashboard)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
        }

        [Given(@"the User has entered (.*) characters for (.*) section on (.*) sub dashboard")]
        public void GivenTheUserHasEnteredText(int characters, string section, string subDashboard)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);

            switch (section)
            {
                case "Supported operating systems":
                    if (subDashboard.Contains("native mobile", System.StringComparison.OrdinalIgnoreCase))
                    {
                        _test.pages.NativeMobileSections.OperatingSystems.SelectCheckboxes(1);
                    }
                    _test.pages.NativeMobileSections.OperatingSystems.TextAreaSendText(characters);
                    break;
                case "Memory and storage":
                    _test.pages.NativeMobileSections.MemoryAndStorage.TextAreaSend(characters);
                    break;
            }
        }

        [Given(@"that a User has not provided any mandatory data on (.*) sub dashboard for (.*) section")]
        public void GivenThatAUserHasNotProvidedAnyMandatoryDataOnNativeMobileOrTabletSubDashboardForSupportedOperatingSystemsSection(string subDashboard, string section)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
        }


        [Given(@"the User has saved all data for (.*) section on (.*) sub dashboard")]
        public void GivenTheUserHasSavedAllDataForSupportedOperatingSystemsSectionOnNativeMobileOrTabletSubDashboard(string section, string subDashboard)
        {
            GivenTheUserHasEnteredText(100, section, subDashboard);

            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.WaitUntilSectionPageNotShownAnymore();
            _test.pages.Common.ClickSubDashboardBackLink();
        }

    }
}
