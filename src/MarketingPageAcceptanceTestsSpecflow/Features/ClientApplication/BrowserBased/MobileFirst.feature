Feature: MobileFirst
	As an Authority User
	I want to edit the Mobile First Sub-Section
	So that I can make sure the information is correct

	N.B Authority User and Supplier used interchangeably 

@ignore
Scenario: Data Saved
	Given that an answer is provided to the mobile first question
	When a User saves the page
	Then the Mobile first section is marked as COMPLETE on the Browser Based Client Type Sub-Form
@ignore
Scenario: Data not Saved
	Given that an answer has not been provided to the mobile first mandatory question
	When the User exits the page
	Then the Mobile first section is marked as INCOMPLETE on the Browser Based Client Type Sub-Form
@ignore
Scenario: Appear on Preview
	Given that an answer is provided to the mobile first question
	And the user has saved the data
	When a User previews the Marketing Page
	Then Mobile first will be presented on the Preview of the Marketing Page
@ignore
Scenario: Mandatory Data Missing Validation
	Given that an answer has not been provided to the mobile first mandatory question
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
@ignore
Scenario: Validation Error Message Anchors
	Given validation has been triggered on Browser based section Mobile first
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page