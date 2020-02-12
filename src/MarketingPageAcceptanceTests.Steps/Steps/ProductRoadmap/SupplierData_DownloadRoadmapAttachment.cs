using System;
using System.IO;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ProductRoadmap
{
    [Binding]
    public class SupplierData_DownloadRoadmapAttachment : TestBase
    {
        public SupplierData_DownloadRoadmapAttachment(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [When(@"the User chooses to download the Roadmap attachment")]
        public void WhenTheUserChoosesToDownloadTheRoadmapAttachment()
        {
            var url = _test.pages.PreviewPage.GetDownloadLinkUrlInSection("Roadmap");
            DownloadFileUtility.DownloadFile("downloadedRoadmap.pdf", _test.downloadPath, url);
        }
        
        [Then(@"the attachment contains the Supplier's Roadmap")]
        public void ThenTheAttachmentContainsTheSupplierSRoadmap()
        {
            _context.Pending();
        }
    }
}
