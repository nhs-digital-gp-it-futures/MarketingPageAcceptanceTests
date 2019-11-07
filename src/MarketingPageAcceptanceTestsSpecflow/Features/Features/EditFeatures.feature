Feature: Suppliers - Edit Features Section
	As a Supplier
	I want to Edit the Features Section
	So that I can make sure the information is correct

Scenario: Feature does not exceed maximum
	Given the Supplier has entered a Feature
	And it does not exceed the maximum character count
	When the Supplier attempts to save 
	Then the Features is saved
	And the database contains the Feature Text

Scenario: Feature does exceed maximum
	Given the Supplier has entered a Feature
	And it does exceed the maximum character count
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
	And the database does not contain the Feature Text	

Scenario: Features Section marked as Complete -  No Mandatory Data
	Given the Features Section has no Mandatory Data
	And a Supplier has saved any data on the Features Section
	When the Marketing Page Form is presented 
	Then the Features Section is marked as Complete
	And the database contains the Feature Text

Scenario: Features Section marked as Incomplete -  No Data
	Given the Features Section has no Mandatory Data
	And a Supplier has not saved any data on the Features Section
	When the Marketing Page Form is presented 
	Then the Features Section is marked as Incomplete

@ignore
Scenario: Validation Error Message Anchors
	Given validation has been triggered
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page