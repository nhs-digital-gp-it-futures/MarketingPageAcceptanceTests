Feature: Suppliers - Native Mobile Connection Details
	As an Authority User
	I want to edit the Connection Details Section
	So that I can make sure the information is correct

Scenario: Does not exceed maximum
	Given the Supplier has entered 300 characters on the Connection details page in the Native mobile or tablet section
	When the User attempts to save 
	Then the Connection details is saved

Scenario: Does exceed maximum
	Given the Supplier has entered 301 characters on the Connection details page in the Native mobile or tablet section
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Native Mobile or Tablet Application Type Sub-Section marked as Incomplete - No Mandatory Data Required
	Given the Connection details Sub-Section in the Native mobile or tablet section does not require Mandatory Data
	And a Supplier has not saved any data in any field within the Sub-Section
	When the Native mobile or tablet Client Application Sub-Form is presented
	Then the Connection details Sub-Section is marked as Incomplete 

Scenario: Native Mobile or Tablet Application Type Sub-Section marked as Complete - No Mandatory Data Required
	Given the Connection details Sub-Section in the Native mobile or tablet section does not require Mandatory Data
	And a Supplier has saved any data in any field within Connection details
	When the Native mobile or tablet Client Application Sub-Form is presented
	Then the Connection details Sub-Section is marked as Complete