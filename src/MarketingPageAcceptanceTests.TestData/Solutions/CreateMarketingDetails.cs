using System;
using Bogus;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class CreateMarketingDetails
    {
        private const string ClientApplicationValue = "{ \"ClientApplicationTypes\":[\"browser-based\"],\"BrowsersSupported\":[\"google-chrome\", \"microsoft-edge\", \"mozilla-firefox\"],\"MobileResponsive\":true, \"Plugins\":{\"Required\":true,\"AdditionalInformation\":\"Additional info about plug-ins\"}}";

        public static MarketingDetail CreateNewMarketingDetail(string slnId, int numFeatures, bool clientApplication = true)
        {
            var faker = new Faker();

            MarketingDetail md = new()
            {
                SolutionId = slnId,
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication = clientApplication ? ClientApplicationValue : string.Empty
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
