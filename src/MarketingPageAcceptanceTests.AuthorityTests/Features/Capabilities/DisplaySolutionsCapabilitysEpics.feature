Feature: Display Solution's Capability's Epics
	As a Public User
	I want to view a Solution's Capability's Epics
	So that I know what Epics the Solution has

Scenario: Solution Capability Epics - Must Epics and May Epics
	Given that Epics for the Capability are provided
	When a User previews the Marketing Page
	Then the Epic titles are visible
	And the Epic IDs are displayed
	And the Epics are displayed as Must or May Epics

Scenario: Solution Capability Epics - Epic Met or Not Met
	Given that Epic Pass or Fail Statuses have been provided for each Epic
	When a User previews the Marketing Page
	Then the Epic pass or fail status is visible

# Need to figure out what happens here, but have used existing steps on the assumption that a validation message will be displayed on save
Scenario: Solution Capability Epics - Epic provided for Capability not provided
	Given that Epics are provided for Capabilities not provided
	When the User attempts to save
	Then the User remains on the Epics page