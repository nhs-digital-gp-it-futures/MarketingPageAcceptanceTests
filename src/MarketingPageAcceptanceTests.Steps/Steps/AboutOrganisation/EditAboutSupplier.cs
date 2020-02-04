using Bogus;
using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps.AboutOrganisation
{
    [Binding]
    public class EditAboutSupplier : TestBase
    {
        string newDescription;
        string newLink;
        public EditAboutSupplier(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"the About supplier section does not require Mandatory Data")]
        public void GivenTheAboutSupplierSectionDoesNotRequireMandatoryData()
        {
            _test.supplier.Summary = "";
            _test.supplier.SupplierUrl = "";
            SqlHelper.UpdateSupplier(_test.supplier, _test.connectionString);
            _test.driver.Navigate().Refresh();
        }

        [Given(@"that About Supplier data has been added to a Solution \(Solution A\)")]
        public void GivenThatAboutSupplierDataHasBeenAddedToASolutionSolutionA()
        {
            _test.supplier = CreateSupplier.CreateNewSupplier();
            SqlHelper.CreateSupplier(_test.supplier, _test.connectionString);
            _test.solution.SupplierId = _test.supplier.Id;
            SqlHelper.UpdateSolutionSupplierId(_test.solution.Id, _test.solution.SupplierId, _test.connectionString);
            _test.listOfSolutions.Add(_test.solution);
        }

        [Given(@"the User has created a new solution for the same supplier \(Solution B\)")]
        public void GivenTheUserHasCreatedANewSolutionForTheSameSupplierSolutionB()
        {
            _test.solution = CreateSolution.CreateNewSolution("SolB");
            _test.solution.SupplierId = _test.supplier.Id;
            _test.solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            SqlHelper.CreateBlankSolution(_test.solution, _test.solutionDetail, _test.connectionString);
            _test.listOfSolutions.Add(_test.solution);
        }

        [StepDefinition(@"the User is editing the About supplier section for Solution B")]
        public void WhenTheUserIsEditingTheAboutSupplierSectionForSolutionB()
        {
            _test.SetUrl(_test.listOfSolutions.Last().Id, "supplier");
            _test.GoToUrl();
            _test.pages.Dashboard.NavigateToSection("About supplier");
        }

        [Then(@"the data will be populated in the About supplier Section")]
        public void ThenTheDataWillBePopulatedInTheAboutSupplierSection()
        {
            _test.pages.AboutSupplier.GetDescriptionText().Should().Be(_test.supplier.Summary);
            _test.pages.AboutSupplier.GetLinkText().Should().Be(_test.supplier.SupplierUrl);
        }

        [When(@"the About Supplier description data is changed for Solution B")]
        public void WhenTheAboutSupplierDescriptionDataIsChangedForSolutionB()
        {
            newDescription = _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(100);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [When(@"the About Supplier link data is changed for Solution B")]
        public void WhenTheAboutSupplierLinkDataIsChangedForSolutionB()
        {
            newLink = new Faker().Internet.Url();
            _test.pages.SolutionDescription.LinkAddText(0, newLink);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the About Supplier data is changed for Solution A as well as for Solution B")]
        public void ThenTheAboutSupplierDataIsChangedForSolutionAAsWellAsForSolutionB()
        {
            Supplier supplierForSolutionA = SqlHelper.GetSupplierForSolution(_test.listOfSolutions[0].Id, _test.connectionString);
            Supplier supplierForSolutionB = SqlHelper.GetSupplierForSolution(_test.listOfSolutions[1].Id, _test.connectionString);

            if (newDescription != null)
                supplierForSolutionA.Summary.Should().Be(newDescription);
            if (newLink != null)
                supplierForSolutionA.SupplierUrl.Should().Be(newLink);

            supplierForSolutionA.Should().BeEquivalentTo(supplierForSolutionB);
        }


    }
}
