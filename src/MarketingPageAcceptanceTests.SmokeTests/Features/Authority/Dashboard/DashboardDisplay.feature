@SmokeTest
@authority
Feature: Authority Dashboard Display

Scenario Outline: Display On Authority Dashboard - Form sections presented
	When the Marketing Page Form is presented
	Then there is a list of Marketing Page Form Sections 
	And the User is able to manage the <Section> Marketing Page Form Section
	
		Examples:
		| Section      |
		| Capabilities |
		| Epics        |

Scenario Outline: Display On Authority Dashboard - Section status
	Given the Section has a content validation status
	When the Marketing Page Form is presented
	Then the <Section> content validation status is displayed
	
		Examples:
		| Section      |
		| Capabilities |
		| Epics        |