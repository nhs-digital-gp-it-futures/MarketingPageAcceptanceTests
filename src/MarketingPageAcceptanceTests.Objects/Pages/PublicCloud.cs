using System;
using System.Collections.Generic;
using System.Text;
using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class PublicCloud
    {
        public By RequiresHscnN3Connectivity => By.CssSelector("div.nhsuk-checkboxes__item");
    }
}
