using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class CreateMarketingDetails
    {
        private const string clientApplicationValue = "{ \"ClientApplicationTypes\":[\"browser-based\"],\"BrowsersSupported\":[\"google-chrome\", \"microsoft-edge\", \"mozilla-firefox\"],\"MobileResponsive\":true}";

        public static MarketingDetail CreateNewMarketingDetail(string slnId, int numFeatures, bool clientApplication = true)
        {
            var faker = new Faker();

            var md = new MarketingDetail
            {
                SolutionId = slnId,
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication = clientApplication ? clientApplicationValue : string.Empty
            };

            return md;
        }

        private static string GenerateFeatures(int numFeatures, Faker faker)
        {
            if( numFeatures <= 0)
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
