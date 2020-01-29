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
            var timestampPrefixed = GetTruncatedTimestamp(prefix);
            var lastChar = GetRandomCharacter();            
            
            var solId = timestampPrefixed.Length > 13 ? timestampPrefixed.Substring(0, 13) : timestampPrefixed;

            return solId + lastChar;
        }

        public static SolutionDetail CreateCompleteSolutionDetail(Solution solution, SolutionDetail solutionDetail)
        {
            return CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, solutionDetail.SolutionDetailId, 5);
        }

        private static string GetRandomCharacter()
        {
            var faker = new Faker();
            List<string> randomChars = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                randomChars.Add(faker.Random.AlphaNumeric(1));
            }

            return Information.RandomInformation.GetRandomItem(randomChars).ToString();
        }

        private static string GetTruncatedTimestamp(string prefix)
        {
            string timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            timestamp = timestamp.Substring(timestamp.Length - prefix.Length);

            return prefix + timestamp;
        }
    }
}
