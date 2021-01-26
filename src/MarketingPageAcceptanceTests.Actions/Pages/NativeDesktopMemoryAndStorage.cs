namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public sealed class NativeDesktopMemoryAndStorage : PageAction
    {
        public NativeDesktopMemoryAndStorage(IWebDriver driver)
            : base(driver)
        {
        }

        public void CompleteAllFields(int stringLength = 300)
        {
            SelectRandomMinimumMemory();

            var storageString = RandomInformation.RandomString(stringLength);
            EnterStorageRequirements(storageString);

            var cpuString = RandomInformation.RandomString(stringLength);
            EnterCpuRequirements(cpuString);

            SelectRandomResolution();
        }

        public void SelectRandomMinimumMemory()
        {
            var minimumMemory =
                new SelectElement(Driver.FindElement(Objects.Pages.MemoryAndStorage.MinimumMemory));
            SelectRandomOption(minimumMemory);
        }

        public void EnterStorageRequirements(string text)
        {
            Driver.FindElement(Objects.Pages.NativeDesktopMemoryStorage.StorageRequirements).SendKeys(text);
        }

        public void EnterCpuRequirements(string text)
        {
            Driver.FindElement(Objects.Pages.NativeDesktopMemoryStorage.MinimumCPU).SendKeys(text);
        }

        public void SelectRandomResolution()
        {
            var resolution =
                new SelectElement(
                    Driver.FindElement(Objects.Pages.NativeDesktopMemoryStorage.RecommendedResolution));
            SelectRandomOption(resolution);
        }

        private static void SelectRandomOption(SelectElement element)
        {
            var index = new Random().Next(1, element.Options.Count);
            element.SelectByIndex(index);
        }
    }
}
