namespace MarketingPageAcceptanceTests.SupplierTests.Utils
{
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
        public void BeforeScenario()
        {
            test.CreateSolution = true;
            test.SetUrl(userType: "authority");
            test.GoToUrl();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (test.Solution.Id.Contains(test.SolutionIdPrefix))
            {
                test.Solution.Delete(test.ConnectionString);
                test.CatalogueItem.Delete(test.ConnectionString);
            }

            try
            {
                foreach (var solution in test.ListOfSolutions)
                {
                    if (solution.Id.Contains(test.SolutionIdPrefix))
                    {
                        solution.Delete(test.ConnectionString);
                        new CatalogueItem { CatalogueItemId = solution.Id }.Delete(test.ConnectionString);
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
                    test.Supplier.Delete(test.ConnectionString);
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
