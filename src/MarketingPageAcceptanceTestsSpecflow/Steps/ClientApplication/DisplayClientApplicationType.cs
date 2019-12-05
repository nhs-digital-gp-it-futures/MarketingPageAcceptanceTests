﻿using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication
{
    [Binding]
    public class DisplayClientApplicationType : TestBase
    {
        public DisplayClientApplicationType(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a Supplier has chosen to manage Client Application Type Information")]
        public void GivenThatASupplierHasChosenToManageClientApplicationTypeInformation()
        {
        }


        [Given(@"the Section has a content validation status")]
        public void GivenTheSectionHasAContentValidationStatus()
        {
            _test.pages.Dashboard.AllSectionsContainStatus();
        }

        [Then(@"there is a list of Marketing Page Form Sections")]
        public void ThenThereIsAListOfMarketingPageFormSections()
        {
            _test.pages.Dashboard.PageDisplayed();
        }

        [Then(@"the Supplier is able to manage the Client Application Type Marketing Page Form Section")]
        public void ThenTheSupplierIsAbleToManageTheClientApplicationTypeMarketingPageFormSection()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
        }

        [Then(@"the (.*) content validation status is displayed")]
        public void ThenTheClientApplicationTypeContentValidationStatusIsDisplayed(string section)
        {
            _test.pages.Dashboard.SectionHasStatus(section).Should().BeTrue();
        }

    }
}
