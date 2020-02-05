Feature: Suppliers - Edit Contact Section
	As an Authority User
	I want to Edit the Contact Section
	So that I can make sure the information is correct

Scenario: Contact Detail - Does not exceed maximum
	Given the Supplier has entered any Contact Detail	
	When the User attempts to save 
	Then the Contact details is saved
	And the contact is saved to the database

Scenario: Contact Detail - Does exceed maximum
	Given the User has entered two Contact Details
	And the Contact Details does exceed the maximum for both contacts
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
	And the Supplier is shown 4 error messages

Scenario: Contact Detail - Section marked as Complete -  Any Data Saved
	Given the Contact Details Section has no Mandatory Data
	And a User has saved any data on the Contact Details Section
	When the Marketing Page Form is presented 
	Then the Contact Details Section is marked as Complete

Scenario: Contact Detail - Section marked as Incomplete -  No Data
	Given the Contact Details Section has no Mandatory Data
	And a User has not saved any data on the Contact Details section
	When the Marketing Page Form is presented 
	Then the Contact Details Section is marked as Incomplete

@BUG_3860
Scenario: Contact Detail - One contact only saves one record
	Given the Supplier has entered any Contact Detail	
	And the User attempts to save 
	Then there is 1 record in the contact table

@BUG_3860
Scenario: Contact Detail - Two contacts saves two records
	Given the User has entered two Contact Details	
	And the User attempts to save 
	Then there are 2 records in the contact table
