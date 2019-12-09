using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.MobileFirst
{
    [Binding]
    public class MobileFirst : TestBase
    {

        public MobileFirst(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that an answer is provided to the mobile first question")]
        public void GivenThatAnAnswerIsProvidedToTheMobileFirstQuestion()
        {
            _context.Pending();
        }
    }
}
