using System;
using Bogus;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class CreateSolutionDetails
    {
        public static SolutionDetail CreateNewSolutionDetail(string slnId, Guid solutionDetailId, int numFeatures, bool clientApplication = true)
        {
            var faker = new Faker();

            var md = new SolutionDetail
            {
                SolutionDetailId = solutionDetailId,
                SolutionId = slnId,
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication = clientApplication ? ClientApplicationStrings.GetClientAppString() : string.Empty,
                Summary = faker.Commerce.ProductName(),
                FullDescription = faker.Name.JobTitle()
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
