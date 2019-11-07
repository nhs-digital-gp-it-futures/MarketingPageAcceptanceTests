Feature: Display Marketing Page Form - Features Section
	As a Supplier
	I want to manage Marketing Page Information for the Solution's Features
	So that I can ensure the information is correct

Scenario: Sections presented
	Given that a Supplier has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	Then there is a list of Marketing Page Form Sections
	And the Supplier is able to manage the Features Marketing Page Form Section

Scenario: Section Status
	Given the Section has a content validation status
	When the Marketing Page Form is presented
	Then the Features content validation status is displayed