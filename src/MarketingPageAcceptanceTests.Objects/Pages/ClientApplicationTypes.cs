using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class ClientApplicationTypes
    {
        public By Checkboxes => By.ClassName("nhsuk-checkboxes__input");

        public By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button");

        public By CheckboxGroups => By.ClassName("nhsuk-checkboxes__item");
    }
}
