using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class HardwareRequirements
    {
        public By HardwareRequirementsDescription => By.CssSelector("textarea.nhsuk-textarea");
    }
}
