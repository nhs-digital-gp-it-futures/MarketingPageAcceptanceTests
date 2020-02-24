Feature: Suppliers - Native desktop - Connectivity
	As an Authority User
	I want to edit the Connectivity Section
	So that I can make sure the information is correct

Background:
	Given the user has set Native desktop application type

Scenario: Native desktop Connectivity - Mandatory - Yes
	Given that Connectivity has been completed for Native desktop
	And has navigated to the Native desktop Client Application Sub-Form
	Then the Connectivity Sub-Section is marked as Complete

Scenario: Native desktop Connectivity - Mandatory - No
	Given the Native desktop Client Application Type Section requires Mandatory Data
	And a Supplier has not saved any data in any field within the Sub-Section
	And has navigated to the Native desktop Client Application Sub-Form
	When the Native desktop Client Application Sub-Form is presented
	Then the Connectivity Sub-Section is marked as Incomplete 

Scenario: Native desktop Connectivity - Validation on Save
	Given validation has been triggered on Native desktop section Connectivity
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

