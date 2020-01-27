Feature: EditAboutSupplier
	As an Authority User
	I want to Edit the About Supplier Section
	So that I can make sure the information is correct

Scenario: About Supplier does not exceed maximum
	Given the User has entered 1000 characters on the About supplier page in the About supplier section
	And I enter 1000 characters into the link field
	When the User attempts to save 
	Then the About supplier is saved

Scenario: About Supplier does exceed maximum
	Given the User has entered 1001 characters on the About supplier page in the About supplier section
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: About Supplier Section marked as Complete -  Any Data Saved
	Given the User has entered 1000 characters on the About supplier page in the About supplier section
	And I enter 1000 characters into the link field
	When the User attempts to save 
	And the Marketing Page Form is presented 
	Then the About supplier section is marked as Complete

Scenario: About Supplier Section marked as Incomplete -  No Data
	Given the About supplier section does not require Mandatory Data
	When the Marketing Page Form is presented 
	Then the About supplier section is marked as Incomplete
@ignore
Scenario: About Supplier Appear on Preview
	Given the User has entered 1000 characters on the About supplier page in the About supplier section
	And I enter 1000 characters into the link field
	When the User attempts to save 
	And a User previews the Marketing Page
	#Then the Roadmap section is presented
@ignore
Scenario: Pre-Populated Description & URL
	Given that a User has previously saved data in the 'About Supplier' Section
	When they were completing the 'About Supplier' Section for another Solution
	Then the data will be populated in the 'About Supplier' Section for all of the Supplier's Solutions
@ignore
Scenario Outline: Changing About Supplier Data
	Given that About Supplier data has been added to a Solution (Solution A)
	When the About Supplier data is pre-populated for another Solution (Solution B)
	And the About Supplier <field> data is changed for Solution B 
	Then the About Supplier data is changed for Solution A as well as for Solution B
	Examples: 
	| field       |
	| description |
	| link        |