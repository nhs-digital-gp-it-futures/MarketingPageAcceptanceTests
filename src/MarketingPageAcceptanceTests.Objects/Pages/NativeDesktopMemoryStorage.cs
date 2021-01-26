namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using OpenQA.Selenium;

    public static class NativeDesktopMemoryStorage
    {
        public static By StorageRequirements => By.Id("storage-requirements-description");

        public static By MinimumCPU => By.Id("minimum-cpu");

        public static By RecommendedResolution => By.CssSelector("select#recommended-resolution");
    }
}
