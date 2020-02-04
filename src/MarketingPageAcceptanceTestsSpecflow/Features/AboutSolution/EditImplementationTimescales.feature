@ignore
Feature: Suppliers - Edit Implementation Timescales
	As an Authority User
	I want to edit the Implementation Timescales Section
	So that I can make sure the information is correct

Scenario: Field does not exceed maximum
	Given the User has entered 1000 characters on the Implementation timescales page in the Implementation timescales section
	When the User attempts to save 
	Then the Implementation timescales is saved

Scenario: Field does exceed maximum
	Given the User has entered 1001 characters on the Implementation timescales page in the Implementation timescales section
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: Implementation Timescales Section marked as Complete -  No Mandatory Data
	Given the Implementation timescales section does not require Mandatory Data
	And a User has saved any data in any field within Implementation timescales
	When the Marketing Page Form is presented 
	Then the Implementation timescales section is marked as Complete

Scenario: Implementation Timescales Section marked as Incomplete -  No Data
	Given the Implementation timescales section does not require Mandatory Data
	And a User has not saved any data on the Implementation timescales section
	When the Marketing Page Form is presented 
	Then the Implementation timescales section is marked as Incomplete
