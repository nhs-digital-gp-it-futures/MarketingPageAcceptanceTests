using System;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class MemoryAndStorage : PageAction
    {
        public MemoryAndStorage(IWebDriver driver) : base(driver)
        {
        }

        public void SelectRequirementFromList(int index = -1)
        {
            var optionsCount = driver.FindElement(Objects.Pages.MemoryAndStorage.MinimumMemory)
                .FindElements(By.TagName("option")).Count;
            if (index == -1) index = new Random().Next(1, optionsCount);

            new SelectElement(driver.FindElement(Objects.Pages.MemoryAndStorage.MinimumMemory))
                .SelectByIndex(index);
        }

        public void TextAreaSend(int characters)
        {
            var text = RandomInformation.RandomString(characters);

            driver.FindElement(Objects.Pages.MemoryAndStorage.DescriptionStorageRequirements)
                .SendKeys(text);
        }
    }
}
