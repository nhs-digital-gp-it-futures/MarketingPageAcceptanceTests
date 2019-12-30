using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class MemoryAndStorage
    {
        public By MinimumMemory => By.CssSelector("select#minimum-memory-requirement");

        public By DescriptionStorageRequirements => By.Id("storage-requirements-description");
    }
}