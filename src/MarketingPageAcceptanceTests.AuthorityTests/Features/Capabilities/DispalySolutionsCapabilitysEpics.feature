@ignore
Feature: Display Solution's Capability's Epics
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

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