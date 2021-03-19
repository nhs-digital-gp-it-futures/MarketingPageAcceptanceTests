namespace MarketingPageAcceptanceTests.Steps.Steps.AboutOrganisation
{
    using System.Linq;
    using System.Threading.Tasks;
    using Bogus;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using MarketingPageAcceptanceTests.TestData.Suppliers;
    using TechTalk.SpecFlow;

    [Binding]
    public class EditAboutSupplier : TestBase
    {
        private string newDescription;
        private string newLink;

        public EditAboutSupplier(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"the About supplier section does not require Mandatory Data")]
        public async Task GivenTheAboutSupplierSectionDoesNotRequireMandatoryDataAsync()
        {
            test.Supplier.Summary = string.Empty;
            test.Supplier.SupplierUrl = string.Empty;
            await test.Supplier.UpdateAsync(test.ConnectionString);
            test.Driver.Navigate().Refresh();
        }

        [Given(@"that About Supplier data has been added to a Solution \(Solution A\)")]
        public async Task GivenThatAboutSupplierDataHasBeenAddedToASolutionSolutionAAsync()
        {
            test.Supplier = GenerateSupplier.GenerateNewSupplier();
            await test.Supplier.CreateAsync(test.ConnectionString);
            test.CatalogueItem.SupplierId = test.Supplier.Id;
            await test.CatalogueItem.UpdateAsync(test.ConnectionString);
            test.ListOfSolutions.Add(test.Solution);
        }

        [Given(@"the User has created a new solution for the same supplier \(Solution B\)")]
        public async Task GivenTheUserHasCreatedANewSolutionForTheSameSupplierSolutionBAsync()
        {
            test.CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem();
            test.Solution = GenerateSolution.GenerateNewSolution(test.CatalogueItem.CatalogueItemId);
            test.CatalogueItem.SupplierId = test.Supplier.Id;
            await test.CatalogueItem.CreateAsync(test.ConnectionString);
            await test.Solution.CreateAsync(test.ConnectionString);
            test.ListOfSolutions.Add(test.Solution);
        }

        [StepDefinition(@"the User is editing the About supplier section for Solution B")]
        public async Task WhenTheUserIsEditingTheAboutSupplierSectionForSolutionBAsync()
        {
            await test.SetUrlAsync(test.ListOfSolutions.Last().Id, "supplier");
            test.GoToUrl();
            test.Pages.Dashboard.NavigateToSection("About supplier");
        }

        [Then(@"the data will be populated in the About supplier Section")]
        public void ThenTheDataWillBePopulatedInTheAboutSupplierSection()
        {
            test.Pages.AboutSupplier.GetDescriptionText().Should().Be(test.Supplier.Summary);
            test.Pages.AboutSupplier.GetLinkText().Should().Be(test.Supplier.SupplierUrl);
        }

        [When(@"the About Supplier description data is changed for Solution B")]
        public void WhenTheAboutSupplierDescriptionDataIsChangedForSolutionB()
        {
            newDescription = test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(100);
            test.Pages.Common.SectionSaveAndReturn();
        }

        [When(@"the About Supplier link data is changed for Solution B")]
        public void WhenTheAboutSupplierLinkDataIsChangedForSolutionB()
        {
            newLink = new Faker().Internet.Url();
            test.Pages.SolutionDescription.LinkAddText(0, newLink);
            test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the About Supplier data is changed for Solution A as well as for Solution B")]
        public async Task ThenTheAboutSupplierDataIsChangedForSolutionAAsWellAsForSolutionBAsync()
        {
            var supplierForSolutionA =
                await Supplier.RetrieveSupplierForSolutionAsync(test.ConnectionString, test.ListOfSolutions[0].Id);
            var supplierForSolutionB =
                await Supplier.RetrieveSupplierForSolutionAsync(test.ConnectionString, test.ListOfSolutions[1].Id);

            if (newDescription != null)
            {
                supplierForSolutionA.Summary.Should().Be(newDescription);
            }

            if (newLink != null)
            {
                supplierForSolutionA.SupplierUrl.Should().Be(newLink);
            }

            supplierForSolutionA.Should().BeEquivalentTo(supplierForSolutionB);
        }
    }
}
