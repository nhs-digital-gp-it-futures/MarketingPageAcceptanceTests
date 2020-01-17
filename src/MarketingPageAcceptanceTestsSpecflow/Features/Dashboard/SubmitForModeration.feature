@ignore
Feature: Supplier - Submit for Moderation
	As a Supplier
	I want to submit my Marketing Page for Moderation
	So that my Marketing Page can be approved and published

Scenario: Mandatory Data Present - Submit
	Given that a Supplier has provided all mandatory data on the Marketing Page
	When the User chooses to Submit their Marketing Page for Moderation
	Then the Marketing Page will be submitted for Moderation
	And the User will be informed that Submission was successful 

Scenario: Mandatory Data Missing - Submit
	Given that a Supplier has not provided all mandatory data on the Marketing Page
	When the User chooses to Submit their Marketing Page for Moderation
	Then the Marketing Page will not be submitted for Moderation
	And the User remains on the Marketing Page Dashboard
	And the User will be notified that the submission was unsuccessful
	And they will be informed why

Scenario: Validation Error Message Anchors
	Given validation has been triggered
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page