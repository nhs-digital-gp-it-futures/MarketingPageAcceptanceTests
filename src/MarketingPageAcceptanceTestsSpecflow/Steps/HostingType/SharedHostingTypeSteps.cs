using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow
{
    [Binding]
    public class SharedHostingTypeSteps : TestBase
    {
        public SharedHostingTypeSteps(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"the User has entered (\d{3,4}) characters on the (.*) page in the (Public cloud|Private cloud|Hybrid|On premise) section")]
        public void GivenTheSupplierHasEnteredText(int characters, string page, string section)
        {
            _test.pages.Dashboard.NavigateToSection(section);

            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(characters);
        }

        [Given(@"the (Public cloud|Private cloud|Hybrid|On premise) section does not require Mandatory Data")]
        public void GivenTheHostingTypeSectionDoesNotRequireMandatoryData(string hostingTypeSection)
        {

        }

        [Given(@"a User has not saved any data on the (Public cloud|Private cloud|Hybrid|On premise) section")]
        public void GivenAUserHasNotSavedAnyDataOnTheHostingTypeSection(string hostingTypeSection)
        {

        }
    }
}
