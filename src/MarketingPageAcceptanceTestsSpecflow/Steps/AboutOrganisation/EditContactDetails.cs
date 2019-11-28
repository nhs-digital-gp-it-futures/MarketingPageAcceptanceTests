using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutOrganisation
{
    [Binding]
    public class EditContactDetails
    {
        private UITest _test;
        private ScenarioContext _context;

        public EditContactDetails(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the User has entered any Contact Detail")]
        public void GivenTheUserHasEnteredAnyContactDetail()
        {
            _context.Pending();
        }

        [Given(@"the Contact Details Section has no Mandatory Data")]
        public void GivenTheContactDetailsSectionHasNoMandatoryData()
        {
            _context.Pending();
        }

        [Given(@"a User has saved any data on the Contact Details Section")]
        public void GivenAUserHasSavedAnyDataOnTheContactDetailsSection()
        {
            _context.Pending();
        }

        [Given(@"a User has not saved any data on the Contact Details Section")]
        public void GivenAUserHasNotSavedAnyDataOnTheContactDetailsSection()
        {
            _context.Pending();
        }

        [Given(@"that data has been saved in this section")]
        public void GivenThatDataHasBeenSavedInThisSection()
        {
            _context.Pending();
        }

        [Then(@"an indication is given to the User as to why")]
        public void ThenAnIndicationIsGivenToTheUserAsToWhy()
        {
            _context.Pending();
        }

        [Then(@"the Contact Details Section is marked as Complete")]
        public void ThenTheContactDetailsSectionIsMarkedAsComplete()
        {
            _context.Pending();
        }

        [Then(@"the Contact Details Section is marked as Incomplete")]
        public void ThenTheContactDetailsSectionIsMarkedAsIncomplete()
        {
            _context.Pending();
        }
    }
}
