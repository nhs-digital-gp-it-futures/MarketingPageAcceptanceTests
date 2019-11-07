using Bogus;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class CreateSolution
    {
        const string prefix = "AutoSol";

        public static Solution CreateNewSolution()
        {
            var faker = new Faker();

            var Id = RandomSolId(faker);
            Solution solution = new Solution
            {
                Id = Id,
                Name = faker.Name.JobTitle(),
                Version = faker.System.Semver()
            };

            return solution;
        }

        private static string RandomSolId(Faker faker)
        {   
            var suffix = faker.Random.Digits(14 - prefix.Length);

            return $"{prefix}{string.Join("",suffix)}";
        }

        public static MarketingDetail CreateCompleteMarketingDetail(Solution solution)
        {
            return CreateMarketingDetails.CreateNewMarketingDetail(solution.Id, 5);
        }
    }
}
