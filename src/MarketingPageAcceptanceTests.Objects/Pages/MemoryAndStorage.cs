namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using OpenQA.Selenium;

    public static class MemoryAndStorage
    {
        public static By MinimumMemory => By.CssSelector("select#minimum-memory-requirement");

        public static By DescriptionStorageRequirements => By.Id("storage-requirements-description");
    }
}
