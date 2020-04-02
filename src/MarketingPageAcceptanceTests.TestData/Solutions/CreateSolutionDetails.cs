using Bogus;
using System;
using System.Diagnostics;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class GenerateSolutionDetails
    {
        public static SolutionDetail GenerateNewSolutionDetail(string slnId, Guid solutionDetailId, int numFeatures,
            bool clientApplication = true, bool roadMap = false, bool hostingTypes = false,
            bool integrationsUrl = false, bool implementationTimescales = false)
        {
            var faker = new Faker();

            var sd = new SolutionDetail
            {
                SolutionDetailId = solutionDetailId,
                SolutionId = slnId,
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication =
                    clientApplication ? ClientApplicationStringBuilder.GetClientAppString() : string.Empty,
                Summary = faker.Commerce.ProductName(),
                FullDescription = faker.Name.JobTitle(),
                RoadMap = roadMap ? faker.Rant.Review() : string.Empty,
                HostingTypes = hostingTypes ? GetCompleteHostingTypes() : string.Empty,
                IntegrationsUrl = integrationsUrl ? faker.Internet.Url() : string.Empty,
                ImplementationTimescales = implementationTimescales ? faker.Lorem.Sentences(2) : string.Empty
            };

            if (Debugger.IsAttached) Console.WriteLine(sd.ToString());

            return sd;
        }

        public static SolutionDetail CreateCompleteSolutionDetail(string slnId, Guid solutionDetailId,
            int numFeatures = 5)
        {
            var faker = new Faker();

            var sd = new SolutionDetail
            {
                SolutionDetailId = solutionDetailId,
                SolutionId = slnId,
                AboutUrl = faker.Internet.Url(),
                Features = GenerateFeatures(numFeatures, faker),
                ClientApplication =
                    ClientApplicationStringBuilder.GetClientAppString(
                        clientApplicationTypes: "Browser-based, Native mobile or tablet, Native desktop"),
                Summary = faker.Commerce.ProductName(),
                FullDescription = faker.Name.JobTitle(),
                RoadMap = faker.Rant.Review(),
                HostingTypes = GetCompleteHostingTypes(),
                IntegrationsUrl = faker.Internet.Url(),
                ImplementationTimescales = faker.Lorem.Sentences(2)
            };

            return sd;
        }

        private static string GetCompleteHostingTypes()
        {
            return HostingTypeStrings.CompleteHostingTypes;
        }

        private static string GenerateFeatures(int numFeatures, Faker faker)
        {
            if (numFeatures <= 0)
                return string.Empty;

            var featuresArray = new string[numFeatures];

            if (numFeatures > 0)
                for (var i = 0; i < numFeatures; i++)
                    featuresArray[i] = $"\"{faker.Commerce.ProductAdjective()}\"";

            return $"[{string.Join(",", featuresArray)}]";
        }
    }
}