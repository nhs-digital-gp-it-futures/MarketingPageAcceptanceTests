Feature: Suppliers - Edit Browser-based Client Type - Plugin or Extension
	As a Supplier
	I want to edit the Plugin or Extension Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Browser-based application type

Scenario: Browser-based Plugin or Extension - Data Saved
	Given that an answer is provided to the Plug-ins or extensions mandatory question
	When a User saves the page
	Then the Plug-ins or extensions required section is marked as COMPLETE on the Browser-based Client Type Sub-Form

Scenario: Browser-based Plugin or Extension - Data not Saved
	Given that an answer has not been provided to the Plug-ins or extensions required mandatory question on the Browser-based section
	When the User exits the page
	Then on the Browser-based dashboard
	And the Plug-ins or extensions required section is marked as INCOMPLETE on the Browser-based Client Type Sub-Form

Scenario: Browser-based Plugin or Extension - Plug in or Extension Description does not exceed maximum
	Given that an answer is provided to the Plug-ins or extensions mandatory question
	And the Supplier has entered Plug-in or extensions description with character count 500
	When the Supplier attempts to save 
	Then the Plug-ins or extensions required section is marked as COMPLETE on the Browser-based Client Type Sub-Form

Scenario: Browser-based Plugin or Extension - Plug in or Extension Description does exceed maximum
	Given that an answer is provided to the Plug-ins or extensions mandatory question
	And the Supplier has entered Plug-in or extensions description with character count 501
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Browser-based Plugin or Extension - Validation Error Message Anchors
	Given validation has been triggered on Browser-based section Plug-ins or extensions required
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page

Scenario: Browser-based Plugin or Extension - Mandatory Data Missing Validation
	Given that a User has not provided any mandatory data for Plug-ins or extensions required
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why