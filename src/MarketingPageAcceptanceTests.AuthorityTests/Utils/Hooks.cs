using MarketingPageAcceptanceTests.Steps.Utils;
using MarketingPageAcceptanceTests.TestData.Solutions;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.SupplierTests.Utils
{
    [Binding]
    public sealed class Hooks
    {
        private readonly UITest _test;

        public Hooks(UITest test)
        {
            _test = test;
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            _test.CreateSolution = true;
            _test.SetUrl(userType: "authority");
            _test.GoToUrl();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_test.solution.Id.Contains(_test.solutionIdPrefix))
            {
                _test.solution.Delete(_test.ConnectionString);
                _test.catalogueItem.Delete(_test.ConnectionString);
            }

            try
            {
                foreach (var solution in _test.listOfSolutions)
                {
                    if (solution.Id.Contains(_test.solutionIdPrefix))
                    {
                        solution.Delete(_test.ConnectionString);
                        new CatalogueItem { CatalogueItemId = solution.Id }.Delete(_test.ConnectionString);
                    }
                }
            }
            finally
            {
                _test.listOfSolutions = null;
            }

            try
            {
                if (_test.supplier != null) _test.supplier.Delete(_test.ConnectionString);
            }
            finally
            {
                _test.supplier = null;
            }

            _test.Driver.Close();
            _test.Driver.Quit();
        }
    }
}
