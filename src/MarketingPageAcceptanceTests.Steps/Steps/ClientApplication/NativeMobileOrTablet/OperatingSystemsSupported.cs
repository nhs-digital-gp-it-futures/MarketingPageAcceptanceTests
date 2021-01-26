namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeMobileOrTablet
{
    using System;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class OperatingSystemsSupported : TestBase
    {
        public OperatingSystemsSupported(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(
            @"that a User has provided a value for the Mandatory Information for (Supported operating systems) section on (Native mobile or tablet) sub dashboard")]
        public void GivenThatAUserHasProvidedAValueForTheMandatoryInformation(string section, string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);

            test.Pages.NativeMobileSections.OperatingSystems.SelectCheckboxes(1);
            test.Pages.Common.SectionSaveAndReturn();
        }

        [Given(
            @"that an answer has not been provided to the mandatory question for (.*) section on (.*) sub dashboard")]
        public void GivenThatAnAnswerHasNotBeenProvidedToTheMandatoryQuestion(string section, string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
        }

        [Given(@"the User has entered (.*) characters for (.*) section on (.*) sub dashboard")]
        public void GivenTheUserHasEnteredText(int characters, string section, string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);

            switch (section)
            {
                case "Supported operating systems":
                    if (subDashboard.Contains("native mobile", StringComparison.OrdinalIgnoreCase))
                    {
                        test.Pages.NativeMobileSections.OperatingSystems.SelectCheckboxes(1);
                    }

                    test.Pages.NativeMobileSections.OperatingSystems.TextAreaSendText(characters);
                    break;
                case "Memory and storage":
                    test.Pages.NativeMobileSections.MemoryAndStorage.TextAreaSend(characters);
                    break;
            }
        }

        [Given(@"that a User has not provided any mandatory data on (.*) sub dashboard for (.*) section")]
        public void
            GivenThatAUserHasNotProvidedAnyMandatoryDataOnNativeMobileOrTabletSubDashboardForSupportedOperatingSystemsSection(
                string subDashboard, string section)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
        }

        [Given(@"the User has saved all data for (.*) section on (.*) sub dashboard")]
        public void GivenTheUserHasSavedAllDataForSupportedOperatingSystemsSectionOnNativeMobileOrTabletSubDashboard(
            string section, string subDashboard)
        {
            GivenTheUserHasEnteredText(100, section, subDashboard);

            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
            test.Pages.Common.ClickSubDashboardBackLink();
        }
    }
}
