﻿using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.StepSetup.Utils;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ProductRoadmap
{
    [Binding]
    public class SupplierData_DownloadRoadmapAttachment : TestBase
    {
        private const string roadmapDownloadFile = "downloadedRoadmap.pdf";

        public SupplierData_DownloadRoadmapAttachment(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [When(@"the User chooses to download the Roadmap attachment")]
        public void WhenTheUserChoosesToDownloadTheRoadmapAttachment()
        {
            var url = _test.Pages.PreviewPage.GetRoadmapDownloadLinkUrl();
            DownloadFileUtility.DownloadFile(roadmapDownloadFile, _test.downloadPath, url);
        }

        [Then(@"the Roadmap attachment is downloaded")]
        public void ThenTheRoadmapAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_test.downloadPath, roadmapDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }


        [Then(@"the attachment contains the Supplier's Roadmap")]
        public void ThenTheAttachmentContainsTheSupplierSRoadmap()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure",
                "SampleData", "roadmap.pdf");
            var downloadedFile = Path.Combine(_test.downloadPath, roadmapDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
        }
    }
}