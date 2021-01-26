namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;

    public sealed class HardwareRequirements : PageAction
    {
        public HardwareRequirements(IWebDriver driver)
            : base(driver)
        {
        }

        public string EnterText(int characters, int fieldIndex = 0)
        {
            var randomText = RandomInformation.RandomString(characters);
            Driver.EnterTextViaJS(
                Wait,
                Objects.Pages.HardwareRequirements.HardwareRequirementsDescription,
                randomText,
                fieldIndex);
            return randomText;
        }
    }
}
