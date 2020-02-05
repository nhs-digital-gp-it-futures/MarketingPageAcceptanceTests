Feature: Suppliers - Edit Browser Based Client Type - Connectivity and Resolution
	As a Supplier
	I want to edit the Resolution and Connectivity Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Browser based application type

Scenario: Connectivity and Resolution - Mandatory - Yes
	Given that a User has provided a value for the Connectivity and resolution Mandatory Information
	When a User saves the page
	Then the Connectivity and resolution section is marked as COMPLETE on the Browser Based Client Type Sub-Form

Scenario: Connectivity and Resolution - Mandatory - No
	Given that an answer has not been provided to the Connectivity and resolution mandatory question on the Browser based section
	When the User exits the page
	Then on the Browser based dashboard
	And the Connectivity and resolution section is marked as INCOMPLETE on the Browser Based Client Type Sub-Form	

Scenario: Connectivity and Resolution - Mandatory Data Missing Validation
	Given that an answer has not been provided to the Connectivity and resolution mandatory question on the Browser based section
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Connectivity and Resolution - Validation Error Message Anchors
	Given validation has been triggered on Browser based section Connectivity and resolution
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page
