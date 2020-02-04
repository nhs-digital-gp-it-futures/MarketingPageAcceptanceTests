Feature: Suppliers - Edit Native Desktop - Third Party Components And Device Capabilities
	As an Authority User
	I want to edit the Third Party + Device Capabilities Section
	So that I can make sure the information is correct

Scenario: Does not exceed maximum
	Given the Supplier has entered 500 characters on the Third party components and device capabilities page in the Native desktop section
	And I enter 500 characters into the second text field
	When the User attempts to save 
	Then the Third party components and device capabilities is saved

Scenario: Does exceed maximum
	Given the Supplier has entered 501 characters on the Third party components and device capabilities page in the Native desktop section
	And I enter 501 characters into the second text field
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
	And the Supplier is shown 2 error messages

Scenario: Native Desktop Application Type Sub-Section marked as Incomplete - No Mandatory Data Required
	Given the Third party components and device capabilities Sub-Section in the Native desktop section does not require Mandatory Data
	And a Supplier has not saved any data in any field within the Sub-Section
	When the Native desktop Client Application Sub-Form is presented
	Then the Third party components and device capabilities Sub-Section is marked as Incomplete

Scenario: Native Desktop Application Type Sub-Section marked as Complete - No Mandatory Data Required
	Given the Connection details Sub-Section in the Native desktop section does not require Mandatory Data
	And a Supplier has saved any data in any field within Third party components and device capabilities
	When the Native desktop Client Application Sub-Form is presented
	Then the Third party components and device capabilities Sub-Section is marked as Complete
