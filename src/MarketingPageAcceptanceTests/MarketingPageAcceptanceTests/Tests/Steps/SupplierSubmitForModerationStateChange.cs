using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/SupplierSubmittedForModerationStateChange.txt")]
    public sealed class SupplierSubmitForModerationStateChange : UITest, IDisposable
    {
        public SupplierSubmitForModerationStateChange(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Marketing Page has been submitted")]
        public void MarketingPageSubmitted()
        {
            throw new NotImplementedException();
        }

        [When("the Supplier submits their Marketing Page")]
        public void SupplierSubmitsMarketingPage()
        {
            throw new NotImplementedException();
        }

        [Then("the Marketing Page state will change")]
        public void MarketingPageStateChange()
        {
            throw new NotImplementedException();
        }

        [And("the State will reflect that the Supplier data has been submitted for moderation")]
        public void StateSupplierSubmittedForModeration()
        {
            throw new NotImplementedException();
        }
    }
}
