using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bogus;
using MarketingPageAcceptanceTests.TestData.Information;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class GenerateCatalogueItem
    {
        public static CatalogueItem GenerateNewCatalogueItem(string prefix = "Auto", bool checkForUnique = false,
            string connectionString = null, int publishedStatus = 1)
        {
            var faker = new Faker();

            var Id = checkForUnique ? UniqueSolIdCheck(prefix, connectionString) : RandomSolId(prefix);

            var catalogueItem = new CatalogueItem
            {
                CatalogueItemId = Id,
                Name = faker.Name.JobTitle(),
                PublishedStatusId = publishedStatus,
                Created = DateTime.Now,
            };

            if (Debugger.IsAttached) Console.WriteLine(catalogueItem.ToString());

            return catalogueItem;
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
            List<string> randomChars = new();
            for (var i = 0; i < 10; i++) randomChars.Add(faker.Random.AlphaNumeric(1));

            return RandomInformation.GetRandomItem(randomChars);
        }

        private static string GetTruncatedTimestamp(string prefix)
        {
            var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            timestamp = timestamp[^prefix.Length..];

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

            var existingSolIds = Solution.RetrieveAll(connectionString).ToList();

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
