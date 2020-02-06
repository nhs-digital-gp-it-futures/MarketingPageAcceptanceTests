﻿using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps.AboutOrganisation
{
    [Binding]
    public class EditContactDetails : TestBase
    {
        IContactDetail firstContact;
        public EditContactDetails(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the (Supplier|Authority User) has entered any Contact Detail")]

        public void GivenTheUserHasEnteredAnyContactDetail(string userType)
        {
            _test.SetUrl(userType: userType);
            _test.GoToUrl();

            firstContact = GenerateContactDetails.NewContactDetail(_test.solution.Id);            

            _test.pages.Dashboard.NavigateToSection("Contact details");
            _test.pages.ContactDetails.EnterAllData(firstContact);
        }

        [Given(@"the User has entered two Contact Details")]

        public void GivenTheUserHasEnteredTwoContactDetails()
        {
            firstContact = GenerateContactDetails.NewContactDetail(_test.solution.Id);            
            var secondContact = GenerateContactDetails.NewContactDetail(_test.solution.Id);

            _test.pages.Dashboard.NavigateToSection("Contact details");
            _test.pages.ContactDetails.EnterAllData(firstContact, secondContact);
        }

        [Given(@"a User has saved any data on the Contact Details Section")]
        public void GivenDataSaved()
        {
            GivenTheUserHasEnteredAnyContactDetail("supplier");

            _test.pages.Common.SectionSaveAndReturn();
        }

        [Given(@"the Contact Details does exceed the maximum for both contacts")]
        public void GivenContactDetailDoesExceedTheMaximumForBothContacts()
        {
            var updatedContact1 = GenerateContactDetails.NewContactDetail(_test.solution.Id);
            var updatedContact2 = GenerateContactDetails.NewContactDetail(_test.solution.Id);
            updatedContact1.FirstName = RandomInformation.RandomString(36);
            updatedContact1.LastName = RandomInformation.RandomString(36);
            updatedContact2.FirstName = RandomInformation.RandomString(36);
            updatedContact2.LastName = RandomInformation.RandomString(36);
            _test.pages.ContactDetails.EnterAllData(updatedContact1, updatedContact2, true);
        }

        [Given(@"the Contact Details Section has no Mandatory Data")]
        public void GivenTheContactDetailsSectionHasNoMandatoryData()
        {
        }

        [Then(@"the Contact Details Section is marked as Complete")]
        public void ThenTheContactDetailsSectionIsMarkedAsComplete()
        {
            _test.pages.Dashboard.SectionCompleteStatus("Contact details");
        }

        [Then(@"the Contact Details Section is marked as Incomplete")]
        public void ThenTheContactDetailsSectionIsMarkedAsIncomplete()
        {
            _test.pages.Dashboard.SectionIncompleteStatus("Contact details");
        }

        [StepDefinition(@"the contact is saved to the database")]
        public void ThenTheContectIsSavedToTheDatabase()
        {   
            var dbContact = firstContact.Get(_test.connectionString);
            dbContact.Should().BeEquivalentTo(firstContact);
        }

        [Then(@"there (is|are) (.*) (record|records) in the contact table")]
        public void ThenThereIsRecordInTheContactTable(string ignore1, int expected, string ignore2)
        {
            var actual = firstContact.GetCount(_test.connectionString);
            actual.Should().Be(expected);
        }

        [Then(@"the correct contact details for the solution is displayed")]
        public void ThenTheCorrectContactDetailsForTheSolutionIsDisplayed()
        {
            _test.pages.PreviewPage.ContactDisplayedOnPreview().Should().BeEquivalentTo(firstContact);
        }
    }
}
