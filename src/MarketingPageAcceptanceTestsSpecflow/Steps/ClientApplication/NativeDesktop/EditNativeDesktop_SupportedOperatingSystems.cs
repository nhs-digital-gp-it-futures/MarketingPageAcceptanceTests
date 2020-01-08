﻿using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.NativeDesktop
{
    [Binding]
    public class EditNativeDesktop_SupportedOperatingSystems : TestBase
    {
        public EditNativeDesktop_SupportedOperatingSystems(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that a User has provided a value for the mandatory information for (Supported operating systems) section on (Native desktop) sub dashboard")]
        public void GivenThatAUserHasProvidedAValueForTheMandatoryInformationForSupportedOperatingSystemsSectionOnNativeDesktopSubDashboard(string section, string subDashboard)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);

            _test.pages.NativeDesktopSections.OperatingSystems.TextAreaSendText(501);
            _test.pages.Common.SectionSaveAndReturn();
        }
    }
}
