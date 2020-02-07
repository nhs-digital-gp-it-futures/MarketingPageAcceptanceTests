Feature: Suppliers - Edit On premise Hosting Type
	As an Authority User
	I want to edit the On Premise Section
	So that I can make sure the information is correct

Scenario: On Premise Hosting Type - Field does not exceed maximum
	Given the Supplier has entered 500 characters on the On premise hosting page in the On premise section
	And I enter 1000 characters into the link field
	And I enter 1000 characters into the second text field
	When the User attempts to save 
	Then the On premise is saved

Scenario: On Premise Hosting Type - Field does exceed maximum
	Given the Supplier has entered 501 characters on the On premise hosting page in the On premise section
	And I enter 1001 characters into the link field
	And I enter 1001 characters into the second text field
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: On Premise Hosting Type - Hosting Section marked as Complete -  Any Data Saved
	Given the On premise section does not require Mandatory Data
	And a User has saved any data in any field within On premise
	When the Marketing Page Form is presented 
	Then the On premise section is marked as Complete

Scenario: On Premise Hosting Type - Hosting Type Section marked as Incomplete -  No Data
	Given the On premise section does not require Mandatory Data
	And a User has not saved any data on the On premise section
	When the Marketing Page Form is presented 
	Then the On premise section is marked as Incomplete

Scenario: On Premise Hosting Type - HSCN/N3 connection does not appear on preview when not checked
	Given that On premise has been completed in the Hosting type section
	And the user unchecks the HSCN/N3 connection checkbox on the On premise section
	When a User previews the Marketing Page
	Then Summary will be presented in On premise on the Preview of the Marketing Page
	And The On premise section does not contain This Solution requires a HSCN/N3 connection on the preview of the marketing page
