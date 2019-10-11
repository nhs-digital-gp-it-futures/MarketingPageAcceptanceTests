using System;
using System.Collections.Generic;
using System.Text;
using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class PreviewPage
    {
        public By PageTitle => By.TagName("h1");

        public By PreviewSection => CustomBy.DataTestId("preview-section");
    }
}
