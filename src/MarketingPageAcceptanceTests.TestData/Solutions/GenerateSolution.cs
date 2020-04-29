using Bogus;
using MarketingPageAcceptanceTests.TestData.Information;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class GenerateSolution
    {
        public static Solution GenerateNewSolution(string prefix, bool checkForUnique = false,
            string connectionString = null)
        {
            var faker = new Faker();

            var Id = checkForUnique ? UniqueSolIdCheck(prefix, connectionString) : RandomSolId(prefix);

            var solution = new Solution
            {
                Id = Id,
                Name = faker.Name.JobTitle(),
                Version = faker.System.Semver(),
                LastUpdated = DateTime.Now,
                LastUpdatedBy = Guid.Empty
            };

            if (Debugger.IsAttached) Console.WriteLine(solution.ToString());

            return solution;
        }


        public static SolutionDetail GenerateCompleteSolutionDetail(Solution solution, SolutionDetail solutionDetail)
        {
            return GenerateSolutionDetails.GenerateNewSolutionDetail(solution.Id, solutionDetail.SolutionDetailId, 5);
        }

        private static string GetSuffix(int solIdLength)
        {
            var suffix = string.Empty;
            for (var i = 0; i < 14 - solIdLength; i++) suffix += GetRandomCharacter();
            return suffix;
        }

        private static string GetRandomCharacter()
        {
            var faker = new Faker();
            var randomChars = new List<string>();
            for (var i = 0; i < 10; i++) randomChars.Add(faker.Random.AlphaNumeric(1));

            return RandomInformation.GetRandomItem(randomChars);
        }

        private static string GetTruncatedTimestamp(string prefix)
        {
            var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            timestamp = timestamp.Substring(timestamp.Length - prefix.Length);

            return prefix + timestamp;
        }

        /// <summary>
        ///     Get list of existing solution ids, then generate new solution ids until a unique solution id is found
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="connectionString"></param>
        /// <returns>A unique solution ID</returns>
        private static string UniqueSolIdCheck(string prefix, string connectionString)
        {
            var solution = new Solution();

            var existingSolIds = solution.RetrieveAll(connectionString).ToList();

            existingSolIds = existingSolIds.Where(s => s.StartsWith(prefix)).ToList();

            var solId = string.Empty;

            for (var i = 0; i < 10; i++)
            {
                solId = RandomSolId(prefix);
                if (!existingSolIds.Contains(solId)) break;
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