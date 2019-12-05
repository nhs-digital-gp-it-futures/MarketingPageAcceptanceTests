Feature: Suppliers - Edit Contact Section
	As an Authority User
	I want to Edit the Contact Section
	So that I can make sure the information is correct

Scenario: Contact Detail does not exceed maximum
	Given the User has entered any Contact Detail	
	When the User attempts to save 
	Then the Contact details is saved
	And the contact is saved to the database

@ignore
Scenario: Contact Detail does exceed maximum
	Given the User has entered any Contact Detail
	And it does exceed the maximum
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: Contact Details Section marked as Complete -  Any Data Saved
	Given the Contact Details Section has no Mandatory Data
	And a User has saved any data on the Contact Details Section
	When the Marketing Page Form is presented 
	Then the Contact Details Section is marked as Complete

Scenario: Contact Details Type Section marked as Incomplete -  No Data
	Given the Contact Details Section has no Mandatory Data
	And a User has not saved any data on the Contact Details Section
	When the Marketing Page Form is presented 
	Then the Contact Details Section is marked as Incomplete

@ignore
Scenario: Appear on Preview
	Given that data has been saved in this section
	When a User previews the Marketing Page
	Then data will be presented on the Preview of the Marketing Page