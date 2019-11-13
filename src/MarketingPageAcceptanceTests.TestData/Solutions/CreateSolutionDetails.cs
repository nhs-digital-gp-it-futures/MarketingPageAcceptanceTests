using Bogus;
using System;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class CreateSolutionDetails
    {
        private const string clientApplicationValue = "{ \"ClientApplicationTypes\":[\"browser-based\"],\"BrowsersSupported\":[\"google-chrome\", \"microsoft-edge\", \"mozilla-firefox\"],\"MobileResponsive\":true, \"Plugins\":{\"Required\":true,\"AdditionalInformation\":\"Additional info about plug-ins\"}}";
        
        public static SolutionDetail CreateNewSolutionDetail(string slnId, int numFeatures, bool clientApplication = true)
        {
            var faker = new Faker();

            var md = new SolutionDetail
            {
                SolutionDetailId = Guid.NewGuid(),
                SolutionId = slnId,
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication = clientApplication ? clientApplicationValue : string.Empty
            };

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine(md.ToString());
            }

            return md;
        }

        private static string GenerateFeatures(int numFeatures, Faker faker)
        {
            if (numFeatures <= 0)
                return string.Empty;

            string[] featuresArray = new string[numFeatures];

            if (numFeatures > 0)
            {
                for (int i = 0; i < numFeatures; i++)
                {
                    featuresArray[i] = $"\"{faker.Commerce.ProductAdjective()}\"";
                }
            }

            return $"[{string.Join(",", featuresArray)}]";
        }
    }
}
