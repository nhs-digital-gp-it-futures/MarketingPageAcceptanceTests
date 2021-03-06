﻿namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Bogus;

    public static class GenerateCatalogueItem
    {
        public static async Task<CatalogueItem> GenerateNewCatalogueItemAsync(string connectionString, int publishedStatus = 1)
        {
            var faker = new Faker();

            var catalogueItem = new CatalogueItem
            {
                Name = faker.Name.JobTitle(),
                PublishedStatusId = publishedStatus,
                Created = DateTime.Now,
            };
            catalogueItem.CatalogueItemId = await RandomSolutionIdAsync(catalogueItem.SupplierId, connectionString);

            return catalogueItem;
        }

        private static async Task<string> RandomSolutionIdAsync(string supplierid, string connectionString)
        {
            var existingSolutions = await CatalogueItem.RetrieveAllAsync(connectionString);

            for (int i = 0; i < 3; i++)
            {
                var randomId = new Random().Next(1, 100000);
                if (!existingSolutions.Contains($"-{randomId}"))
                {
                    return $"{supplierid}-{randomId:D5}";
                }
            }

            throw new DataException("Unable to generate unique solution ID in 3 iterations");
        }
    }
}
