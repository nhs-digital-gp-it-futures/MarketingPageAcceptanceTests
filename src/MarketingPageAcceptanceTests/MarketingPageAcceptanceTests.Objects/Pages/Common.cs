using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class Common
    {
        public By PageTitle => CustomBy.DataTestId("section-title");
    }
}
