Feature: Native Desktop - Memory, Storage, Processing and Resolution
	As an Authority User
	I want to edit the Memory, Storage, Processing and Resolution Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Native desktop application type

Scenario: Mandatory - Yes
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop
	And has navigated to the Native desktop Client Application Sub-Form
	Then the Memory, storage, processing and aspect ratio Sub-Section is marked as Complete

Scenario: Mandatory - No
	Given the Native desktop Client Application Type Section requires Mandatory Data
	And a Supplier has not saved any data in any field within the Sub-Section
	And has navigated to the Native desktop Client Application Sub-Form
	When the Native desktop Client Application Sub-Form is presented
	Then the Memory, storage, processing and aspect ratio Sub-Section is marked as Incomplete 

Scenario: Does not exceed maximum
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop with 300 characters
	When the User attempts to save 
	Then the Memory, storage, processing and aspect ratio is saved

Scenario: Does exceed maximum
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop with 301 characters	
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Appear on Preview
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop
	When a User previews the Marketing Page
	Then Additional storage requirements will be presented in Native desktop on the Preview of the Marketing Page
	And Minimum memory requirement will be presented in Native desktop on the Preview of the Marketing Page
	And Minimum necessary CPU power will be presented in Native desktop on the Preview of the Marketing Page
	And Recommended desktop aspect ratio and screen resolution will be presented in Native desktop on the Preview of the Marketing Page


Scenario: Validation on Save
	Given validation has been triggered on Native desktop section Memory, storage, processing and aspect ratio
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
