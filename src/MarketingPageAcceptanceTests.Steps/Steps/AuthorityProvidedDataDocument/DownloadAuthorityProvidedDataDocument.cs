using System;
using System.IO;
using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.AuthorityProvidedDataDocument
{
    [Binding]
    public class DownloadAuthorityProvidedDataDocument : TestBase
    {
        const string providedDataDocumentDownloadFile = "downloaded Authority Provided Data Document.pdf";
        public DownloadAuthorityProvidedDataDocument(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [When(@"the User chooses to download the Authority Provided Data Document")]
        public void WhenTheUserChoosesToDownloadTheAuthorityProvidedDataDocument()
        {
            var url = _test.pages.PreviewPage.GetDownloadLinkUrlInSection("Learn more");
            DownloadFileUtility.DownloadFile(providedDataDocumentDownloadFile, _test.downloadPath, url);
        }
        
        [Then(@"the Authority Provided Data Document is downloaded")]
        public void ThenTheAuthorityProvidedDataDocumentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_test.downloadPath, providedDataDocumentDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }
        
        [Then(@"the attachment contains the Supplier's Authority Provided Data Document")]
        public void ThenTheAttachmentContainsTheSupplierSAuthorityProvidedDataDocument()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", "Authority Provided Data Document.pdf");
            var downloadedFile = Path.Combine(_test.downloadPath, providedDataDocumentDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
        }

    }
}
