Feature: Mobile First
	As an Authority User
	I want to edit the Mobile First Sub-Section
	So that I can make sure the information is correct

	N.B Authority User and Supplier used interchangeably 

Background:
	Given the user has set Native mobile or tablet application type

Scenario: Data Saved
	Given that an answer is provided to the Native mobile or tablet mobile first question
	When a User saves the page
	Then the Mobile first section is marked as COMPLETE on the Browser Based Client Type Sub-Form

Scenario: Data not Saved
	Given that an answer has not been provided to the Mobile first mandatory question on the Native mobile or tablet section
	When the User exits the page
	Then on the Native mobile or tablet dashboard
	And the Mobile first section is marked as INCOMPLETE on the Browser Based Client Type Sub-Form

Scenario: Appear on Preview
	Given that an answer is provided to the Native mobile or tablet mobile first question
	And the user has saved the data
	When a User previews the Marketing Page
	Then Designed with a mobile first approach will be presented in Native mobile or tablet on the Preview of the Marketing Page

Scenario: Mandatory Data Missing Validation
	Given that an answer has not been provided to the Mobile first mandatory question on the Native mobile or tablet section
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Validation Error Message Anchors
	Given validation has been triggered on Native mobile or tablet section Mobile first
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page