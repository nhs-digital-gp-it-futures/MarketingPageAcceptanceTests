Feature: Suppliers - Display On Authority Dashboard
	As an Authority User
	I want to manage Marketing Page Information
	So that I can ensure the information is correct

@ignore
Scenario Outline: Display On Authority Dashboard - Form sections presented
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	Then there is a list of Marketing Page Form Sections 
	And the User is able to manage the <Section> Marketing Page Form Section
	
		Examples:
		| Section      |
		| Capabilities |

Scenario Outline: Display On Authority Dashboard - Section status
	Given the Section has a content validation status
	When the Marketing Page Form is presented
	Then the <Section> content validation status is displayed
	
		Examples:
		| Section     |
		| Capabilites |
		