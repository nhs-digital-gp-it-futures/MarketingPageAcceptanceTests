namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Bogus;
    using MarketingPageAcceptanceTests.TestData.Information;

    public static class GenerateCatalogueItem
    {
        public static CatalogueItem GenerateNewCatalogueItem(int publishedStatus = 1)
        {
            var faker = new Faker();

            var catalogueItem = new CatalogueItem
            {
                Name = faker.Name.JobTitle(),
                PublishedStatusId = publishedStatus,
                Created = DateTime.Now,
            };
            catalogueItem.CatalogueItemId = RandomSolutionId(catalogueItem.SupplierId);

            if (Debugger.IsAttached)
            {
                Console.WriteLine(catalogueItem.ToString());
            }

            return catalogueItem;
        }

        private static string RandomSolutionId(string supplierid)
        {
            return $"{supplierid}-{new Random().Next(1, 100000):D5}";
        }
    }
}
