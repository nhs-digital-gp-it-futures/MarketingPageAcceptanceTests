using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class NativeDesktopMemoryAndStorage : PageAction
    {
        public NativeDesktopMemoryAndStorage(IWebDriver driver) : base(driver)
        {
        }

        public void CompleteAllFields(int stringLength = 300)
        {
            SelectRandomMinimumMemory();

            string storageString = RandomInformation.RandomString(stringLength);
            EnterStorageRequirements(storageString);

            string cpuString = RandomInformation.RandomString(stringLength);
            EnterCpuRequirements(cpuString);

            SelectRandomResolution();
        }

        public void SelectRandomMinimumMemory()
        {
            var minimumMemory = new SelectElement(driver.FindElement(pages.NativeMobileSections.MemoryAndStorage.MinimumMemory));
            SelectRandomOption(minimumMemory);
        }

        public void EnterStorageRequirements(string text)
        {
            driver.FindElement(pages.NativeDesktopSections.MemoryAndStorage.StorageRequirements).SendKeys(text);
        }

        public void EnterCpuRequirements(string text)
        {
            driver.FindElement(pages.NativeDesktopSections.MemoryAndStorage.MinimumCPU).SendKeys(text);
        }

        public void SelectRandomResolution()
        {
            var resolution = new SelectElement(driver.FindElement(pages.NativeDesktopSections.MemoryAndStorage.RecommendedResolution));
            SelectRandomOption(resolution);
        }

        private void SelectRandomOption(SelectElement element)
        {
            var index = new Random().Next(1, element.Options.Count);
            element.SelectByIndex(index);
        }
    }
}