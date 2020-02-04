Feature: Suppliers - Roadmap
	As an Authority User
	I want to Edit the Roadmap Section
	So that I can make sure the information is correct

Scenario: Roadmap Description does not exceed maximum
	Given the User has entered 1000 characters on the Roadmap page in the Roadmap section
	When the User attempts to save 
	Then the Roadmap is saved

Scenario: Roadmap Description does exceed maximum
	Given the User has entered 1001 characters on the Roadmap page in the Roadmap section
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: Roadmap Section marked as Complete -  Any Data Saved
	Given the User has entered 1000 characters on the Roadmap page in the Roadmap section
	When the User attempts to save 
	And the Marketing Page Form is presented 
	Then the Roadmap section is marked as Complete

Scenario: Roadmap Section marked as Incomplete -  No Data
	Given the Roadmap section does not require Mandatory Data
	When the Marketing Page Form is presented 
	Then the Roadmap section is marked as Incomplete
