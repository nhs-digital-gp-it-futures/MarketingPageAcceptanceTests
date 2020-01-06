Feature: Display Marketing Page Form - Native Desktop Client Type
	As an Authority User
	I want to manage Marketing Page Information for the Native Desktop Client Type Section
	So that I can ensure the information is correct

Scenario: Native Mobile or Tablet Client Type Type Sub-Dashboard presented
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	And the User has selected Native desktop Client Type as a Client Application Type
	Then there is a list of Marketing Page Form Sections 
	And the Authority User is able to access the Native desktop Client Type Type Sub-Dashboard

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
