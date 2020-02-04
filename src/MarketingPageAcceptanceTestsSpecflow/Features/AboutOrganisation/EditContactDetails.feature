Feature: Suppliers - Edit Contact Section
	As an Authority User
	I want to Edit the Contact Section
	So that I can make sure the information is correct

Scenario: Contact Detail does not exceed maximum
	Given the Supplier has entered any Contact Detail	
	When the User attempts to save 
	Then the Contact details is saved
	And the contact is saved to the database

Scenario: Contact Detail does exceed maximum
	Given the User has entered two Contact Details
	And the Contact Details does exceed the maximum for both contacts
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
	And the Supplier is shown 4 error messages

Scenario: Contact Details Section marked as Complete -  Any Data Saved
	Given the Contact Details Section has no Mandatory Data
	And a User has saved any data on the Contact Details Section
	When the Marketing Page Form is presented 
	Then the Contact Details Section is marked as Complete

Scenario: Contact Details Type Section marked as Incomplete -  No Data
	Given the Contact Details Section has no Mandatory Data
	And a User has not saved any data on the Contact Details section
	When the Marketing Page Form is presented 
	Then the Contact Details Section is marked as Incomplete

@BUG_3860
Scenario: One contact only saves one record
	Given the Supplier has entered any Contact Detail	
	And the User attempts to save 
	Then there is 1 record in the contact table

@BUG_3860
Scenario: Two contacts saves two records
	Given the User has entered two Contact Details	
	And the User attempts to save 
	Then there are 2 records in the contact table
