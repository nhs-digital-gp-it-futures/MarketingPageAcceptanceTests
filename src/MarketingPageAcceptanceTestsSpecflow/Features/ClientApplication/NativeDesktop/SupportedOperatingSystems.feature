Feature: Edit Native Desktop - Supported Operating Systems
	As an Authority User
	I want to edit the Operating Systems Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Native desktop application type

Scenario: Sub-Section is marked as Complete with mandatory data only
	Given that a User has provided a value for the mandatory information for Supported operating systems section on Native desktop sub dashboard
	Then the Supported operating systems Sub-Section is marked as Complete 

Scenario: Sub-Section is marked as Incomplete
	Given that an answer has not been provided to the mandatory question for Supported operating systems section on Native desktop sub dashboard
	Then the Supported operating systems Sub-Section is marked as Incomplete 

Scenario: Supported operating systems does not exceed maximum
	Given the User has entered 1000 characters for Supported operating systems section on Native desktop sub dashboard
	When the User attempts to save 
	Then the Supported operating systems is saved

Scenario: Supported operating systems does exceed maximum
	Given the User has entered 1001 characters for Supported operating systems section on Native desktop sub dashboard
	When the Supplier attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Appear on Preview - Supported operating systems
	Given the User has saved all data for Supported operating systems section on Native desktop sub dashboard	
	When a User previews the Marketing Page
	Then Supported operating systems will be presented in Native desktop on the Preview of the Marketing Page

Scenario: Supported operating systems Mandatory Data Missing Validation
	Given that a User has not provided any mandatory data on Native desktop sub dashboard for Supported operating systems section
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Supported operating systems Validation Error Message Anchors
	Given validation has been triggered on Native desktop section Supported operating systems
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page
