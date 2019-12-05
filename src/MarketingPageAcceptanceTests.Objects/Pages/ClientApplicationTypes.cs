using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class ClientApplicationTypes
    {
        public By Checkboxes => By.ClassName("nhsuk-checkboxes__input");



        public By CheckboxGroups => By.ClassName("nhsuk-checkboxes__item");
    }
}
