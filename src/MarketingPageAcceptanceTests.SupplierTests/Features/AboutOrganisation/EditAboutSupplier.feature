Feature: Suppliers - Edit About Supplier
	As an Authority User
	I want to Edit the About Supplier Section
	So that I can make sure the information is correct

Background: 
	Given that About Supplier data has been added to a Solution (Solution A)

Scenario: About Supplier Section - Does not exceed maximum
	Given the Supplier has entered 1000 characters on the About supplier page in the About supplier section
	And I enter 1000 characters into the link field
	When the User attempts to save 
	Then the About supplier is saved

Scenario: About Supplier Section - Does exceed maximum
	Given the Supplier has entered 1101 characters on the About supplier page in the About supplier section
	And I enter 1101 characters into the link field
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why
	And the Supplier is shown 2 error messages

Scenario: About Supplier Section - Marked as Complete -  Any Data Saved
	Given the Supplier has entered 1000 characters on the About supplier page in the About supplier section
	And I enter 1000 characters into the link field
	When the User attempts to save 
	And the Marketing Page Form is presented 
	Then the About supplier section is marked as Complete

Scenario: About Supplier Section - Marked as Incomplete -  No Data
	Given the About supplier section does not require Mandatory Data
	When the Marketing Page Form is presented 
	Then the About supplier section is marked as Incomplete

Scenario: About Supplier Section - Pre-Populated Description & URL
	Given the User has created a new solution for the same supplier (Solution B)
	When the User is editing the About supplier section for Solution B
	Then the data will be populated in the About supplier Section

Scenario Outline: About Supplier Section - Changing About Supplier Data
	Given the User has created a new solution for the same supplier (Solution B)
	And the User is editing the About supplier section for Solution B
	When the About Supplier <field> data is changed for Solution B 
	Then the About Supplier data is changed for Solution A as well as for Solution B
	Examples: 
	| field       |
	| description |
	| link        |