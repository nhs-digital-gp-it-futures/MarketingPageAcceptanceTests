Feature: Display Marketing Page Form - Native Mobile or Tablet Client Type
	As an Authority User
	I want to manage Marketing Page Information for the Native Mobile or Tablet Client Type Section
	So that I can ensure the information is correct

@ignore
Scenario: Native Mobile or Tablet Client Type Type Sub-Dashboard presented
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	And the User has selected Native Mobile or Tablet Client Type as a Client Application Type
	Then there is a list of Marketing Page Form Sections 
	And the Authority User is able to access the Native Mobile or Tablet Client Type Type Sub-Dashboard
@ignore
Scenario: Sub Sections presented
	Given that a User has chosen to manage Marketing Page Information
	When the User has selected Native Mobile or Tablet Client Type as a Client Application Type
	And has navigated to the Native mobile or tablet Client Application Sub-Form
	Then there is a list of Native Mobile or Tablet Client Application Type Sub-Sections 
@ignore
Scenario: Section status
	Given each Native mobile or tablet Sub-Section has a content validation status
	When the Marketing Page Form is presented
	Then the Supported operating systems content validation status is displayed
	#And the Mobile first content validation status is displayed
	#And the Memory and storage content validation status is displayed
	#And the Connection details content validation status is displayed
	#And the Third party components and device capabilities content validation status is displayed
	#And the Hardware requirements content validation status is displayed
	#And the Additional information content validation status is displayed