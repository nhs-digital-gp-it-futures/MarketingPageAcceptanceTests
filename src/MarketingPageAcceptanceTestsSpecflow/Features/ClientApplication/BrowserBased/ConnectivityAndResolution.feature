Feature: Suppliers - Edit Browser Based Client Type - Connectivity and Resolution
	As a Supplier
	I want to edit the Resolution and Connectivity Sub-Section
	So that I can make sure the information is correct

@ignore
Scenario: Mandatory - Yes
	Given that a User has provided a value for the Mandatory Information
	When the User is managing their Connectivity and Resolution Information
	Then the Section is marked as 'complete' on the Browser Based Client Type Sub-Form

@ignore
Scenario:  Mandatory - No
	Given that an answer has not provided to the mandatory question
	When the User exits the page
	Then the Section is marked as 'incomplete' on the Browser Based Client Type Sub-Form

@ignore
Scenario: Appear on Preview
	Given that data has been saved in Connectivity and resolution
	When a User previews the Marketing Page
	Then data will be presented on the Preview of the Marketing Page

@ignore
Scenario: Mandatory Data Missing Validation
	Given that a User has not provided any mandatory data
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

@ignore
	Scenario: Validation Error Message Anchors
	Given validation has been triggered for Connectivity and resolution
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page
