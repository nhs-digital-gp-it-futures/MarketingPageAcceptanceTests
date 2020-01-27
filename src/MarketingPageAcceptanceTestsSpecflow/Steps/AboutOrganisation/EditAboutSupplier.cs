using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutOrganisation
{
    [Binding]
    public class EditAboutSupplier : TestBase
    {
        public EditAboutSupplier(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Then(@"the About supplier section is presented")]
        public void ThenTheAboutSupplierSectionIsPresented()
        {
            _test.pages.PreviewPage.AboutSupplierSectionDisplayed();
        }
    }
}
