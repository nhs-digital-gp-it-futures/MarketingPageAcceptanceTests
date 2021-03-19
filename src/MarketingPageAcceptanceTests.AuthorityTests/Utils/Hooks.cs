namespace MarketingPageAcceptanceTests.SupplierTests.Utils
{
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Hooks
    {
        private readonly UITest test;

        public Hooks(UITest test)
        {
            this.test = test;
        }

        [BeforeScenario(Order = 1)]
        public async Task BeforeScenarioAsync()
        {
            test.CreateSolution = true;
            await test.SetUrlAsync(userType: "authority");
            test.GoToUrl();
        }

        [AfterScenario]
        public async Task AfterScenarioAsync()
        {
            if (test.Solution.Id.Contains(test.SolutionIdPrefix))
            {
                await test.Solution.DeleteAsync(test.ConnectionString);
                await test.CatalogueItem.DeleteAsync(test.ConnectionString);
            }

            try
            {
                foreach (var solution in test.ListOfSolutions)
                {
                    if (solution.Id.Contains(test.SolutionIdPrefix))
                    {
                        await solution.DeleteAsync(test.ConnectionString);
                        await new CatalogueItem { CatalogueItemId = solution.Id }.DeleteAsync(test.ConnectionString);
                    }
                }
            }
            finally
            {
                test.ListOfSolutions.Clear();
            }

            try
            {
                if (test.Supplier != null)
                {
                    await test.Supplier.DeleteAsync(test.ConnectionString);
                }
            }
            finally
            {
                test.Supplier = null;
            }

            test.Driver?.Close();
            test.Driver?.Quit();
        }
    }
}
