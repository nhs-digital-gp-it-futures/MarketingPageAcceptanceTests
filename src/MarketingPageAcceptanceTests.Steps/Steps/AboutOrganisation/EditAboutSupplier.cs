using System;
using System.Linq;
using Bogus;
using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.AboutOrganisation
{
    [Binding]
    public class EditAboutSupplier : TestBase
    {
        private string newDescription;
        private string newLink;

        public EditAboutSupplier(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the About supplier section does not require Mandatory Data")]
        public void GivenTheAboutSupplierSectionDoesNotRequireMandatoryData()
        {
            _test.supplier.Summary = "";
            _test.supplier.SupplierUrl = "";
            _test.supplier.Update(_test.ConnectionString);
            _test.Driver.Navigate().Refresh();
        }

        [Given(@"that About Supplier data has been added to a Solution \(Solution A\)")]
        public void GivenThatAboutSupplierDataHasBeenAddedToASolutionSolutionA()
        {
            _test.supplier = GenerateSupplier.GenerateNewSupplier();
            _test.supplier.Create(_test.ConnectionString);
            _test.solution.SupplierId = _test.supplier.Id;
            _test.solution.Update(_test.ConnectionString);
            _test.listOfSolutions.Add(_test.solution);
        }

        [Given(@"the User has created a new solution for the same supplier \(Solution B\)")]
        public void GivenTheUserHasCreatedANewSolutionForTheSameSupplierSolutionB()
        {
            _test.solution = GenerateSolution.GenerateNewSolution("SolB");
            _test.solution.SupplierId = _test.supplier.Id;
            _test.solution.Create(_test.ConnectionString);

            _test.solutionDetail =
                GenerateSolutionDetails.GenerateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            _test.solutionDetail.Create(_test.ConnectionString);

            _test.solution.SolutionDetailId = _test.solutionDetail.SolutionDetailId;
            _test.solution.Update(_test.ConnectionString);

            _test.listOfSolutions.Add(_test.solution);
        }

        [StepDefinition(@"the User is editing the About supplier section for Solution B")]
        public void WhenTheUserIsEditingTheAboutSupplierSectionForSolutionB()
        {
            _test.SetUrl(_test.listOfSolutions.Last().Id, "supplier");
            _test.GoToUrl();
            _test.Pages.Dashboard.NavigateToSection("About supplier");
        }

        [Then(@"the data will be populated in the About supplier Section")]
        public void ThenTheDataWillBePopulatedInTheAboutSupplierSection()
        {
            _test.Pages.AboutSupplier.GetDescriptionText().Should().Be(_test.supplier.Summary);
            _test.Pages.AboutSupplier.GetLinkText().Should().Be(_test.supplier.SupplierUrl);
        }

        [When(@"the About Supplier description data is changed for Solution B")]
        public void WhenTheAboutSupplierDescriptionDataIsChangedForSolutionB()
        {
            newDescription = _test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(100);
            _test.Pages.Common.SectionSaveAndReturn();
        }

        [When(@"the About Supplier link data is changed for Solution B")]
        public void WhenTheAboutSupplierLinkDataIsChangedForSolutionB()
        {
            newLink = new Faker().Internet.Url();
            _test.Pages.SolutionDescription.LinkAddText(0, newLink);
            _test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the About Supplier data is changed for Solution A as well as for Solution B")]
        public void ThenTheAboutSupplierDataIsChangedForSolutionAAsWellAsForSolutionB()
        {
            var supplierForSolutionA =
                new Supplier().RetrieveSupplierForSolution(_test.ConnectionString, _test.listOfSolutions[0].Id);
            var supplierForSolutionB =
                new Supplier().RetrieveSupplierForSolution(_test.ConnectionString, _test.listOfSolutions[1].Id);

            if (newDescription != null)
                supplierForSolutionA.Summary.Should().Be(newDescription);
            if (newLink != null)
                supplierForSolutionA.SupplierUrl.Should().Be(newLink);

            supplierForSolutionA.Should().BeEquivalentTo(supplierForSolutionB);
        }
    }
}