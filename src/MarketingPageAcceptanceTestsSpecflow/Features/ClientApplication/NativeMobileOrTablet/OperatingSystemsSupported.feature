@ignore
Feature: OperatingSystemsSupported
	As an Authority User
	I want to edit the Operating Systems Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Native mobile or tablet application type

Scenario: Mandatory - Yes
	Given that a User has provided a value for the Mandatory Information for Supported operating systems section on Native mobile or tablet sub dashboard
	Then the Supported operating systems Sub-Section is marked as Complete 

Scenario: Data not Saved
	Given that an answer has not been provided to the mandatory question for Supported operating systems section on Native mobile or tablet sub dashboard
	Then the Supported operating systems Sub-Section is marked as Incomplete 

Scenario: Supported operating systems does not exceed maximum
	Given the User has entered 1000 characters for Supported operating systems section on Native mobile or tablet sub dashboard
	When the User attempts to save 
	Then the Supported operating systems is saved

Scenario: Supported operating systems does exceed maximum
	Given the User has entered 1001 characters for Supported operating systems section on Native mobile or tablet sub dashboard
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Appear on Preview - Supported operating systems
	Given the User has saved all data for Supported operating systems section on Native mobile or tablet sub dashboard	
	When a User previews the Marketing Page
	Then Supported operating systems will be presented in Native mobile or tablet on the Preview of the Marketing Page

Scenario: Supported operating systems Mandatory Data Missing Validation
	Given that a User has not provided any mandatory data on Native mobile or tablet sub dashboard for Supported operating systems section
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Supported operating systems Validation Error Message Anchors
	Given validation has been triggered on Native mobile or tablet section Supported operating systems
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page
