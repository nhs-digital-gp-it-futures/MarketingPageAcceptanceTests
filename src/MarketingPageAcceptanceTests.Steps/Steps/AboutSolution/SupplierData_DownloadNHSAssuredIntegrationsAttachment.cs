using System;
using System.IO;
using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.AboutSolution
{
    [Binding]
    public class SupplierData_DownloadNHSAssuredIntegrationsAttachment : TestBase
    {
        const string integrationsDownloadFile = "downloadedIntegrations.pdf";
        public SupplierData_DownloadNHSAssuredIntegrationsAttachment(UITest test, ScenarioContext context) : base(test, context)
        {                
        }

        [When(@"the User chooses to download the Integrations attachment")]
        public void WhenTheUserChoosesToDownloadTheIntegrationsAttachment()
        {
            var url = _test.pages.PreviewPage.GetDownloadLinkUrlInSection("Integrations");
            DownloadFileUtility.DownloadFile(integrationsDownloadFile, _test.downloadPath, url);
        }

        [Then(@"the Integrations attachment is downloaded")]
        public void ThenTheIntegrationsAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_test.downloadPath, integrationsDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }
        
        [Then(@"the attachment contains the Supplier's NHS Assured Integrations")]
        public void ThenTheAttachmentContainsTheSupplierSNHSAssuredIntegrations()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", "integrations.pdf");
            var downloadedFile = Path.Combine(_test.downloadPath, integrationsDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
        }
    }
}
