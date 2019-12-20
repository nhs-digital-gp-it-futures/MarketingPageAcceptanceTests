Feature: OperatingSystemsSupported
	As an Authority User
	I want to edit the Operating Systems Sub-Section
	So that I can make sure the information is correct

Scenario: Mandatory - Yes
Given that a User has provided a value for the Mandatory Information
When the User is managing their Operating System Information
Then the Supported operating systems Sub-Section is marked as Complete 

Scenario: Data not Saved
Given that an answer has not been provided to the mandatory question
When the User exits the page
Then the Supported operating systems Sub-Section is marked as Incomplete 

Scenario: Supported operating systems does not exceed maximum
Given the User has entered text
And it does not exceed the maximum character count
When the User attempts to save 
Then the Section is saved

Scenario: Supported operating systems does exceed maximum
Given the User has entered text
And it does exceed the maximum character count
When the User attempts to save 
Then the Section is not saved 
And an indication is given to the User as to why

Scenario: Appear on Preview - Supported operating systems
Given that data has been saved in this section
When a User previews the Marketing Page
Then data will be presented on the Preview of the Marketing Page

Scenario: Supported operating systems Mandatory Data Missing Validation
Given that a User has not provided any mandatory data
When the User attempts to save
Then the Section is not saved 
And an indication is given to the User as to why

Scenario: Supported operating systems Validation Error Message Anchors
Given validation has been triggered
When the User selects an error link in the Error Summary
Then the User will be navigated to the relevant section on the page
