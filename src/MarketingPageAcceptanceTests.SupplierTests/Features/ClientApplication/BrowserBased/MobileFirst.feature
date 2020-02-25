Feature: Suppliers - Browser-based Mobile First
	As an Authority User
	I want to edit the Mobile First Sub-Section
	So that I can make sure the information is correct

	N.B Authority User and Supplier used interchangeably 

Background:
	Given the user has set Browser-based application type

Scenario: Browser-based Mobile First - Data Saved
	Given that an answer is provided to the Browser-based mobile first question
	When a User saves the page
	Then the Mobile first approach section is marked as COMPLETE on the Browser-based Client Type Sub-Form

Scenario: Browser-based Mobile First - Data not Saved
	Given that an answer has not been provided to the Mobile first approach mandatory question on the Browser-based section
	When the User exits the page
	Then on the Browser-based dashboard
	And the Mobile first approach section is marked as INCOMPLETE on the Browser-based Client Type Sub-Form

Scenario: Browser-based Mobile First - Mandatory Data Missing Validation
	Given that an answer has not been provided to the Mobile first approach mandatory question on the Browser-based section
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Browser-based Mobile First - Validation Error Message Anchors
	Given validation has been triggered on Browser-based section Mobile first approach
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page