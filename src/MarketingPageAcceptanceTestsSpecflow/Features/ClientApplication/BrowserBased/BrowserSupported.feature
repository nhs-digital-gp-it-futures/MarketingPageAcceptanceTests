﻿Feature: Suppliers - Edit Browser Based Client Type - Browser Supported
	As a Supplier
	I want to edit the Browsers Supported Sub-Section
	So that I can make sure the information is correct

Scenario: Data Saved
	Given that an answer is provided to all questions
	When a User saves the page
	Then the Section is marked as COMPLETE on the Browser Based Client Type Sub-Form

Scenario: Appear on Preview
	Given that data has been saved in this section
	When a User previews the Marketing Page
	Then data will be presented on the Preview of the Marketing Page

Scenario: Validation on Submission
	Given that an answer is not provided to both questions
	When the User submits their Marketing Page for moderation
	Then the Submission will trigger validation
	And the User will be informed that they need to answer the Browsers Supported section before they can submit

Scenario: No Response 
	Given that an answer is not provided to both questions
	When a User saves the page
	Then the Section is not saved because it is mandatory to answer both questions
	And an indication is given to the Supplier as to why
