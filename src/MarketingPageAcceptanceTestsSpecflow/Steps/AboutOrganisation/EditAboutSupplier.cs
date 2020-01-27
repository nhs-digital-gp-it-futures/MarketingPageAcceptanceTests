using System;
using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutOrganisation
{
    [Binding]
    public class EditAboutSupplier : TestBase
    {
        public EditAboutSupplier(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Then(@"the About supplier section is presented")]
        public void ThenTheAboutSupplierSectionIsPresented()
        {
            _test.pages.PreviewPage.AboutSupplierSectionDisplayed();
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
            _test.solution = CreateSolution.CreateNewSolution();
            _test.solution.SupplierId = _test.supplier.Id;
            _test.solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false);
            SqlHelper.CreateBlankSolution(_test.solution, _test.solutionDetail, _test.connectionString);
            _test.listOfSolutions.Add(_test.solution);
        }

        [When(@"the User is editing the About supplier section for Solution B")]
        public void WhenTheUserIsEditingTheAboutSupplierSectionForSolutionB()
        {
            _test.SetUrl(_test.solution.Id);
            _test.GoToUrl();
            _test.pages.Dashboard.NavigateToSection("About supplier");
        }

        [Then(@"the data will be populated in the About supplier Section")]
        public void ThenTheDataWillBePopulatedInTheAboutSupplierSection()
        {
            _test.pages.AboutSupplier.GetDescriptionText().Should().Be(_test.supplier.Summary);
            _test.pages.AboutSupplier.GetLinkText().Should().Be(_test.supplier.SupplierUrl);
        }


    }
}
