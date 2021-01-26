namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeDesktop
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class EditNativeDesktop_SupportedOperatingSystems : TestBase
    {
        public EditNativeDesktop_SupportedOperatingSystems(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(
            @"that a User has provided a value for the mandatory information for (Supported operating systems) section on (Native desktop) sub dashboard")]
        public void
            GivenThatAUserHasProvidedAValueForTheMandatoryInformationForSupportedOperatingSystemsSectionOnNativeDesktopSubDashboard(
                string section, string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);

            test.Pages.NativeDesktopSections.OperatingSystems.TextAreaSendText(501);
            test.Pages.Common.SectionSaveAndReturn();
        }
    }
}
