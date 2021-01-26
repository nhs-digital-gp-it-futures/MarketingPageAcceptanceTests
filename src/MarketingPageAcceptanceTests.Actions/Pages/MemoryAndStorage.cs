namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class MemoryAndStorage : PageAction
    {
        public MemoryAndStorage(IWebDriver driver)
            : base(driver)
        {
        }

        public void SelectRequirementFromList(int index = -1)
        {
            var optionsCount = Driver.FindElement(Objects.Pages.MemoryAndStorage.MinimumMemory)
                .FindElements(By.TagName("option")).Count;
            if (index == -1)
            {
                index = new Random().Next(1, optionsCount);
            }

            new SelectElement(Driver.FindElement(Objects.Pages.MemoryAndStorage.MinimumMemory))
                .SelectByIndex(index);
        }

        public void TextAreaSend(int characters)
        {
            var text = RandomInformation.RandomString(characters);

            Driver.FindElement(Objects.Pages.MemoryAndStorage.DescriptionStorageRequirements)
                .SendKeys(text);
        }
    }
}
