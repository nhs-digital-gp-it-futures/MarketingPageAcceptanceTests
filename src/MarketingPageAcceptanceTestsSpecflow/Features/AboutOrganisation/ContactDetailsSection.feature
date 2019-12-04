Feature: Display Marketing Page Form - Contact Details Section
	As an Authority User
	I want to manage Marketing Page Information for the Solution Contact Details
	So that I can ensure the information is correct

Scenario: Sections presented
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	Then there is a list of Marketing Page Form Sections 
	And the User is able to manage the Contact Details Marketing Page Form Section

Scenario: Section status
	Given the Section has a content validation status
	When the Marketing Page Form is presented
	Then the Contact details content validation status is displayed
