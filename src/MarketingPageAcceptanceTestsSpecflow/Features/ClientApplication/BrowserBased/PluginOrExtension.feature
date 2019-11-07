Feature: Suppliers - Edit Browser Based Client Type - Plugin or Extension
	As a Supplier
	I want to edit the Plugin or Extension Sub-Section
	So that I can make sure the information is correct

@ignore
Scenario: Data Saved
	Given that an answer is provided to the mandatory question
	When a User saves the page
	Then the Section is marked as 'complete' on the Browser Based Client Type Sub-Form

@ignore
Scenario: Data not Saved
	Given that an answer has not been provided to the mandatory question
	When the User exits the page
	Then the Section is marked as 'incomplete' on the Browser Based Client Type Sub-Form

@ignore
Scenario: Plug in or Extension Description does not exceed maximum
	Given the Supplier has entered text
	And it does not exceed the maximum character count
	When the Supplier attempts to save 
	Then the Section is saved

@ignore
Scenario: Plug in or Extension Description does exceed maximum
	Given the Supplier has entered text
	And it does exceed the maximum character count
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

@ignore
Scenario: Appear on Preview
	Given that data has been saved in this section
	When a User previews the Marketing Page
	Then data will be presented on the Preview of the Marketing Page

@ignore
Scenario: Validation Error Message Anchors
	Given validation has been triggered
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page

@ignore
Scenario: Mandatory Data Missing Validation
	Given that a User has not provided any mandatory data
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why