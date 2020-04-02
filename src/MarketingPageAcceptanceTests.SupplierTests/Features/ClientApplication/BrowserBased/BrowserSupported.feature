Feature: Suppliers - Edit Browser-based Client Type - Browser Supported
	As a Supplier
	I want to edit the Browsers Supported Sub-Section
	So that I can make sure the information is correct

Scenario: Browser Supported - Data Saved
	Given that an answer is provided to all Browser supported questions
	When a User saves the page
	Then the Supported browsers section is marked as COMPLETE on the Browser-based Client Type Sub-Form

#ignored as part of 5869
@ignore
Scenario: Browser Supported - Validation on Submission
	Given that an answer is not provided to both questions for Browsers supported
	When the User submits their Marketing Page for moderation
	Then the Submission will trigger validation
	And the User will be informed that they need to answer the Browsers Supported section before they can submit

Scenario: Browser Supported - No Response 
	Given that an answer is not provided to both questions for Browsers supported
	When a User saves the page
	Then the Section is not saved because it is mandatory to answer both questions
	And an indication is given to the Supplier as to why
