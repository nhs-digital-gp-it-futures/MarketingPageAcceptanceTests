namespace MarketingPageAcceptanceTests.Steps.Steps.AboutOrganisation
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.ContactDetails;
    using MarketingPageAcceptanceTests.TestData.Information;
    using TechTalk.SpecFlow;

    [Binding]
    public class EditContactDetails : TestBase
    {
        private IContactDetail firstContact;

        public EditContactDetails(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"the Contact Details Section has no Mandatory Data")]
        public static void NoAction()
        {
        }

        [Given(@"the (Supplier|Authority User) has entered any Contact Detail")]
        public void GivenTheUserHasEnteredAnyContactDetail(string userType)
        {
            test.SetUrl(userType: userType);
            test.GoToUrl();

            firstContact = GenerateContactDetails.NewContactDetail(test.Solution.Id);

            test.Pages.Dashboard.NavigateToSection("Contact details");
            test.Pages.ContactDetails.EnterAllData(firstContact);
        }

        [Given(@"the User has entered two Contact Details")]
        public void GivenTheUserHasEnteredTwoContactDetails()
        {
            firstContact = GenerateContactDetails.NewContactDetail(test.Solution.Id);
            var secondContact = GenerateContactDetails.NewContactDetail(test.Solution.Id);

            test.Pages.Dashboard.NavigateToSection("Contact details");
            test.Pages.ContactDetails.EnterAllData(firstContact, secondContact);
        }

        [Given(@"a User has saved any data on the Contact Details Section")]
        public void GivenDataSaved()
        {
            GivenTheUserHasEnteredAnyContactDetail("supplier");

            test.Pages.Common.SectionSaveAndReturn();
        }

        [Given(@"the Contact Details does exceed the maximum for both contacts")]
        public void GivenContactDetailDoesExceedTheMaximumForBothContacts()
        {
            var updatedContact1 = GenerateContactDetails.NewContactDetail(test.Solution.Id);
            var updatedContact2 = GenerateContactDetails.NewContactDetail(test.Solution.Id);
            updatedContact1.FirstName = RandomInformation.RandomString(36);
            updatedContact1.LastName = RandomInformation.RandomString(36);
            updatedContact2.FirstName = RandomInformation.RandomString(36);
            updatedContact2.LastName = RandomInformation.RandomString(36);
            test.Pages.ContactDetails.EnterAllData(updatedContact1, updatedContact2, true);
        }

        [Then(@"the Contact Details Section is marked as Complete")]
        public void ThenTheContactDetailsSectionIsMarkedAsComplete()
        {
            test.Pages.Dashboard.SectionCompleteStatus("Contact details");
        }

        [Then(@"the Contact Details Section is marked as Incomplete")]
        public void ThenTheContactDetailsSectionIsMarkedAsIncomplete()
        {
            test.Pages.Dashboard.SectionIncompleteStatus("Contact details");
        }

        [StepDefinition(@"the contact is saved to the database")]
        public void ThenTheContectIsSavedToTheDatabase()
        {
            var dbContact = firstContact.Retrieve(test.ConnectionString);
            dbContact.Should().BeEquivalentTo(firstContact);
        }

        [Then(@"there (is|are) (.*) (record|records) in the contact table")]
        public void ThenThereIsRecordInTheContactTable(string ignore1, int expected, string ignore2)
        {
            var actual = firstContact.RetrieveCount(test.ConnectionString);
            actual.Should().Be(expected);
        }

        [Then(@"the correct contact details for the solution is displayed")]
        public void ThenTheCorrectContactDetailsForTheSolutionIsDisplayed()
        {
            test.Pages.PreviewPage.ContactDisplayedOnPreview().Should().BeEquivalentTo(firstContact);
        }
    }
}
