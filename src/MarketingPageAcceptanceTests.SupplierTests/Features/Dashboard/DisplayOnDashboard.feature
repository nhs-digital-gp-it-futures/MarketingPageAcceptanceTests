﻿Feature: Suppliers - Display On Dashboard
	As an Authority User
	I want to manage Marketing Page Information
	So that I can ensure the information is correct

Scenario Outline: Display On Dashboard - Form sections presented
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	Then there is a list of Marketing Page Form Sections 
	And the User is able to manage the <Section> Marketing Page Form Section
	
		Examples:
		| Section                   |
		| Solution description      |
		| Features                  |
		| Client application type   |
		| Public cloud              |
		| Private cloud             |
		| Hybrid                    |
		| On premise                |
		| Contact details           |
		| Roadmap                   |
		| About supplier            |
		| Integrations              |
		| Implementation timescales |
	
Scenario Outline: Display On Dashboard - Sub dashboard sections presented
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	And the User has selected <Section> Client Type as a Client Application Type
	Then there is a list of Marketing Page Form Sections 
	And the User is able to manage the <Section> Marketing Page Dashboard

	Examples:
	| Section                 |
	| Browser-based           |
	| Native mobile or tablet |
	| Native desktop          |

Scenario Outline: Display On Dashboard - Section status
	Given the Section has a content validation status
	When the Marketing Page Form is presented
	Then the <Section> content validation status is displayed
	
		Examples:
		| Section                   |
		| Solution description      |
		| Features                  |
		| Client application type   |
		| Public cloud              |
		| Private cloud             |
		| Hybrid                    |
		| On premise                |
		| Contact details           |
		| Roadmap                   |
		| About supplier            |
		| Integrations              |
		| Implementation timescales |
	
Scenario Outline: Display On Dashboard - Sub dashboard section status
	Given that a User has chosen to manage Marketing Page Information
	When the Marketing Page Form is presented
	And the User has selected <Section> Client Type as a Client Application Type
	Then there is a list of Marketing Page Form Sections 
	Then the <Section> content validation status is displayed

		Examples:
		| Section                 |
		| Browser-based           |
		| Native mobile or tablet |
		| Native desktop          |