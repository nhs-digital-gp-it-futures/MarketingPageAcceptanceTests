Feature: Suppliers - Edit Browser Based Client Type - Hardware Requirements
	As a Supplier
	I want to edit the Hardware Section
	So that I can make sure the information is correct

@ignore
Scenario: Does not exceed maximum
	Given the Supplier has entered text on the Hardware requirements page
	And it does not exceed the maximum character count
	When the Supplier attempts to save 
	Then the Hardware requirements is saved

@ignore
Scenario: Does exceed maximum
	Given the Supplier has entered text on the Hardware requirements page
	And it does exceed the maximum character count
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

@ignore
Scenario: Sub-Section marked as Incomplete - No Mandatory Data Required + no data
	Given the Browser Based Client Application Type Sub-Section does not require Mandatory Data
	And a Supplier has not saved any data in any field within the Sub-Section
	When the Browser Based Client Application Sub-Form is presented
	Then the Browser Based Client Application Type Sub-Section is marked as Incomplete 

@ignore
Scenario: Sub-Section marked as Complete - No Mandatory Data Required + data present
	Given the Browser Based Client Application Type Sub-Section does not require Mandatory Data
	And a Supplier has saved any data in any field within the Sub-Section
	When the Browser Based Client Application Sub-Form is presented
	Then the Browser Based Client Application Type Sub-Section is marked as Complete

@ignore
Scenario: Appear on Preview
	Given that data has been saved in this section
	When a User previews the Marketing Page
	Then data will be presented on the Preview of the Marketing Page