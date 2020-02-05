Feature: Suppliers - Display Sub-Form - Browser Based Client Type
	As a Supplier
	I want to manage Marketing Page Information for the Browser Based Client Type Section
	So that I can ensure the information is correct

Scenario: Browser Based Dashboard - Sub Sections presented
	Given that a Supplier has chosen to manage the Browser Based Client Application Type Section
	When the User has selected Browser based Client Type as a Client Application Type
	And has navigated to the Browser based Client Application Sub-Form
	Then there is a list of Browser Based Client Application Type Sub-Sections 
	And the Supplier is able to access the Browser Based Client Type Sub-Sections

Scenario: Browser Based Dashboard - Section status
	Given each Browser based Sub-Section has a content validation status
	When the Marketing Page Form is presented
	Then the Browsers supported content validation status is displayed
	And the Plug-ins or extensions content validation status is displayed
	And the Connectivity and resolution content validation status is displayed
	And the Hardware requirements content validation status is displayed
	And the Additional information content validation status is displayed
	And the Mobile first content validation status is displayed

Scenario: Browser Based Dashboard - Main Form - Browser Based Application Type Section marked as Incomplete -  Mandatory Data Missing
	Given the Browser based Client Application Type Section requires Mandatory Data
	And the User has selected Browser based Client Type as a Client Application Type
	And a Supplier has not saved Mandatory data on all the Browser Based Client Application Type Sub-Sections
	When the Marketing Page Form is presented
	Then the Browser based Sub-Section is marked as Incomplete

Scenario: Browser Based Dashboard - Main Form - Client Application Type Section marked as Complete -  Mandatory Data Present
	Given the Browser based Client Application Type Section requires Mandatory Data
	And the User has selected Browser based Client Type as a Client Application Type
	And a Supplier has saved all mandatory data on the Browser based Client Application Type Sub-Sections
	When the Marketing Page Form is presented 
	Then the Browser based Sub-Section is marked as Complete

Scenario Outline: Browser Based Dashboard - Main Form - Client Application Type Section marked as Incomplete - Some data missing
	Given the Browser based Client Application Type Section requires Mandatory Data
	And a Supplier has saved all mandatory data on the Browser based Client Application Type Sub-Sections except for <section>
	When the Marketing Page Form is presented 	
	Then the Browser based Sub-Section is marked as Incomplete

	Examples: 
	| section                     |
	| Browsers supported          |
	| Plug-ins or extensions      |
	| Connectivity and resolution |
	| Mobile first				  |