Feature: DashboardDisplay

@SmokeTest
Scenario Outline: Display On Supplier Dashboard - Form sections presented
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