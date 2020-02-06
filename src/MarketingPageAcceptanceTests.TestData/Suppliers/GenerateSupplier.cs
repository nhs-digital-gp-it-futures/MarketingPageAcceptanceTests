using Bogus;

namespace MarketingPageAcceptanceTests.TestData.Suppliers
{
    public static class GenerateSupplier
    {
        public static Supplier GenerateNewSupplier()
        {
            var faker = new Faker();
            var id = faker.Random.Int(900000, 999999).ToString();
            Supplier supplier = new Supplier()
            {
                Id = id,
                Name = faker.Company.CompanyName(),
                Summary = faker.Company.Bs(),
                SupplierUrl = faker.Internet.Url()
            };
            supplier.LegalName = supplier.Name + " plc";
            return supplier;
        }
    }
}
