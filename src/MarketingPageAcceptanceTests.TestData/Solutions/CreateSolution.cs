using Bogus;
using System;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class CreateSolution
    {
        public static Solution CreateNewSolution(string prefix = "Auto")
        {
            var faker = new Faker();

            var Id = RandomSolId(prefix);
            Solution solution = new Solution
            {
                Id = Id,
                Name = faker.Name.JobTitle(),
                Version = faker.System.Semver()
            };

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine(solution.ToString());
            }

            return solution;
        }

        private static string RandomSolId(string prefix)
        {
            var faker = new Faker();
            List<string> randomChars = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                randomChars.Add(faker.Random.AlphaNumeric(1));
            }

            var randomChar = Information.RandomInformation.GetRandomItem(randomChars).ToString();

            string timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            timestamp = timestamp.Substring(timestamp.Length - prefix.Length);

            string totalString = prefix + timestamp;

            return totalString.Length > 13 ? totalString.Substring(0, 13) + randomChar : totalString + randomChar;
        }

        public static SolutionDetail CreateCompleteSolutionDetail(Solution solution, SolutionDetail solutionDetail)
        {
            return CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, solutionDetail.SolutionDetailId, 5);
        }
    }
}
