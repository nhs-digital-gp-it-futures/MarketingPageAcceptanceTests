Feature: Display Marketing Page Form - Client Application Type
	As a Supplier
	I want to define the Client Application Types of my Solution
	So that I can add further information about each Client Application Type

Scenario: Sections presented
	Given that a Supplier has chosen to manage Client Application Type Information
	When the Marketing Page Form is presented
	Then there is a list of Marketing Page Form Sections 
	And the Supplier is able to manage the Client Application Type Marketing Page Form Section

Scenario: Section status
	Given the Section has a content validation status
	When the Marketing Page Form is presented
	Then the Client application type content validation status is displayed