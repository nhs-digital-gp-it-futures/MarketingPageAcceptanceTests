Feature: Suppliers - Native Desktop Client Type Sub Dashboard
	As an Authority User
	I want to manage Marketing Page Information for the Native Desktop Client Type Section
	So that I can ensure the information is correct

Scenario: Sub Sections presented
	Given that a User has chosen to manage Marketing Page Information
	When the User has selected Native desktop Client Type as a Client Application Type
	And has navigated to the Native desktop Client Application Sub-Form
	Then there is a list of Native Desktop Client Application Type Sub-Sections 

Scenario: Section status
	Given each Native desktop Sub-Section has a content validation status
	When the Marketing Page Form is presented
	Then the Supported operating systems content validation status is displayed
	And the Connection details content validation status is displayed
	And the Memory, storage, processing and aspect ratio content validation status is displayed
	And the Third party components and device capabilities content validation status is displayed
	And the Hardware requirements content validation status is displayed
	And the Additional information content validation status is displayed

Scenario: Main Form - Section marked as Complete -  Mandatory Data Present
	Given the Native desktop Client Application Type Section requires Mandatory Data
	And the User has selected Native desktop Client Type as a Client Application Type
	And a Supplier has saved all mandatory data on the Native desktop Client Application Type Sub-Sections
	When the Marketing Page Form is presented 
	Then the Native desktop Sub-Section is marked as Complete

Scenario Outline: Main Form - Section marked as Incomplete - Some data missing
	Given the Native desktop Client Application Type Section requires Mandatory Data
	And a Supplier has saved all mandatory data on the Native desktop Client Application Type Sub-Sections except for <section>
	When the Marketing Page Form is presented 	
	Then the Native desktop Sub-Section is marked as Incomplete

	Examples: 
	| section										|
	| Supported operating systems					|
	| Connection details							|
	| Memory, storage, processing and aspect ratio  |