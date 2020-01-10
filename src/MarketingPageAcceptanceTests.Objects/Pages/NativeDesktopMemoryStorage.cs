using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class NativeDesktopMemoryStorage
    {
        public By StorageRequirements => By.Id("storage-requirements-description");
        public By MinimumCPU => By.Id("minimum-cpu");

        public By RecommendedResolution => By.CssSelector("select#recommended-resolution");
    }
}
