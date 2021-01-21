using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class ClientApplicationTypes
    {
        public static By Checkboxes => By.ClassName("nhsuk-checkboxes__input");

        public static By CheckboxGroups => By.ClassName("nhsuk-checkboxes__item");
    }
}
