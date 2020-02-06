Feature: Suppliers - Native Desktop - Memory, Storage, Processing and Resolution
	As an Authority User
	I want to edit the Memory, Storage, Processing and Resolution Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Native desktop application type

Scenario: Native Desktop Memory, Storage, Processing and Resolution - Mandatory - Yes
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop
	And has navigated to the Native desktop Client Application Sub-Form
	Then the Memory, storage, processing and aspect ratio Sub-Section is marked as Complete

Scenario: Native Desktop Memory, Storage, Processing and Resolution - Mandatory - No
	Given the Native desktop Client Application Type Section requires Mandatory Data
	And a Supplier has not saved any data in any field within the Sub-Section
	And has navigated to the Native desktop Client Application Sub-Form
	When the Native desktop Client Application Sub-Form is presented
	Then the Memory, storage, processing and aspect ratio Sub-Section is marked as Incomplete 

Scenario: Native Desktop Memory, Storage, Processing and Resolution - Does not exceed maximum
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop with 300 characters
	When the User attempts to save 
	Then the Memory, storage, processing and aspect ratio is saved

Scenario: Native Desktop Memory, Storage, Processing and Resolution - Does exceed maximum
	Given that Memory, storage, processing and aspect ratio has been completed for Native desktop with 301 characters	
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Native Desktop Memory, Storage, Processing and Resolution - Validation on Save
	Given validation has been triggered on Native desktop section Memory, storage, processing and aspect ratio
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why
