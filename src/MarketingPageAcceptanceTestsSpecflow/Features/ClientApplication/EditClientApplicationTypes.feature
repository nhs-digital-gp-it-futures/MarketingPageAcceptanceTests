Feature: Suppliers - Edit Client Application Type
	As a Supplier
	I want to select my Client Application Types
	So that I can add further information for each Client Application Type

Scenario: Client Application Type Selected
	Given that a Client Application Type is selected
	When the section is saved
	Then the selected Client Application Type sub-category is available on the Marketing Page Form

Scenario: Client Application Type Not Selected
	Given that a Client Application Type is not selected
	Then no Client Application Type sub-category is available on the Marketing Page Form
	And there is a guidance message informing the User they need to select a Client Application Type

Scenario: Client Application Type Section marked as Incomplete -  Mandatory Data Missing
	Given the Client Application Type Section requires Mandatory Data
	And a Supplier has not saved any data on the Client Application Type Section
	When the Marketing Page Form is presented
	Then the Client Application Type Section is marked as Incomplete

Scenario:  Client Application Type Section marked as Complete -  Mandatory Data Present
	Given the Client Application Type Section requires Mandatory Data
	And a Supplier has saved any data on the Client Application Type Section
	When the Marketing Page Form is presented
	Then the Client Application Type Section is marked as Complete

Scenario: Validation on Submission
	Given validation has been triggered on Client application type section
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page