using Bogus;
using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class CreateSolution
    {
        public static Solution CreateNewSolution(string prefix = "Auto", bool checkForUnique = false, string connectionString = null)
        {
            var faker = new Faker();

            var Id = checkForUnique ? UniqueSolIdCheck(prefix, connectionString) : RandomSolId(prefix);

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

        

        public static SolutionDetail CreateCompleteSolutionDetail(Solution solution, SolutionDetail solutionDetail)
        {
            return CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, solutionDetail.SolutionDetailId, 5);
        }

        private static string GetSuffix(int solIdLength)
        {
            var suffix = string.Empty;
            for (int i = 0; i < 14 - solIdLength; i++)
            {
                suffix += GetRandomCharacter();
            }
            return suffix;
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

        /// <summary>
        /// Get list of existing solution ids, then generate new solution ids until a unique solution id is found
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="connectionString"></param>
        /// <returns>A unique solution ID</returns>
        private static string UniqueSolIdCheck(string prefix, string connectionString)
        {
            var existingSolIds = SqlHelper.GetAllSolutionIds(connectionString).ToList();

            var solId = string.Empty;

            for(var i = 0; i < 10; i++)
            {
                solId = RandomSolId(prefix);
                if (!existingSolIds.Contains(solId))
                {
                    break;
                }
            }

            return solId;
        }

        private static string RandomSolId(string prefix)
        {
            var timestampPrefixed = GetTruncatedTimestamp(prefix);

            var solId = timestampPrefixed.Length > 13 ? timestampPrefixed.Substring(0, 13) : timestampPrefixed;
            var suffix = GetSuffix(solId.Length);

            return solId + suffix;
        }
    }
}
