Feature: Suppliers - Edit Solution Description Section
	As a Supplier
	I want to Edit the About Solution Section
	So that I can make sure the information is correct

Scenario: Field does not exceed maximum
	Given the Supplier has entered data into any field
	And it does not exceed the maximum
	When the Supplier attempts to save 
	Then the Solution description is saved

Scenario: Field does exceed maximum
	Given the Supplier has entered data into any field
	And it does exceed the maximum
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Solution Description Section marked as Incomplete Mandatory Data Missing
	Given the Solution Description Section requires Mandatory Data
	And the pre-populated data is not present
	When the Marketing Page Form is presented 
	Then the Solution Description Section is marked as Incomplete

Scenario: Solution Description Section marked as Complete
	Given the Supplier has entered data into any field
	And it does not exceed the maximum
	When the Supplier attempts to save
	And the Marketing Page Form is presented 
	Then the Solution description section is marked as Complete

Scenario: Validation Error Message Anchors
	Given validation has been triggered on Solution description section
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page

Scenario: No Summary
	Given that a Supplier has not provided a Summary Description
	When the Supplier attempts to save 
	Then the Section is not saved
	And an indication is given to the Supplier as to why