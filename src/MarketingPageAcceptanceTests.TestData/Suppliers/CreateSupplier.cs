using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace MarketingPageAcceptanceTests.TestData.Suppliers
{
    public static class CreateSupplier
    {
        public static Supplier CreateNewSupplier()
        {
            var faker = new Faker();
            var id = faker.Random.Int(900000, 999999).ToString();
            Supplier supplier = new Supplier
            {
                Id = id,
                Name = faker.Company.CompanyName(),
                Summary = faker.Company.Bs(),
                SupplierUrl = faker.Internet.Url()
            };
            return supplier;
        }
    }
}
