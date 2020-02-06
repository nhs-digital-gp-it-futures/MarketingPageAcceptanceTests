Feature: Suppliers - Edit Supplier Asserted Integrations Section
	As an Authority User
	I want to Edit the Supplier Asserted Integrations Section
	So that I can make sure the information is correct

Scenario: Integrations - Field does not exceed maximum
	Given the Supplier has entered 1000 characters on the Catalogue Solution integrations page in the Integrations section
	When the User attempts to save 
	Then the Integrations is saved

Scenario: Integrations - Field does exceed maximum
	Given the Supplier has entered 1001 characters on the Catalogue Solution integrations page in the Integrations section
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: Integrations - Marked as Complete -  Any Data Saved
	Given the Integrations section does not require Mandatory Data
	And a Supplier has saved any data on the Integrations page
	When the Marketing Page Form is presented 
	Then the Integrations section is marked as Complete

Scenario: Integrations - Marked as Incomplete -  No Data
	Given the Integrations section does not require Mandatory Data
	And a User has not saved any data on the Integrations section
	When the Marketing Page Form is presented 
	Then the Integrations section is marked as Incomplete
