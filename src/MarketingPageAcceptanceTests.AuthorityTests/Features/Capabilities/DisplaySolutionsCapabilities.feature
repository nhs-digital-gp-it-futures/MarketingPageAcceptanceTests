Feature: Display Solution's Capabilities
	As a Public User
	I want to view a Solution's Capabilities
	So that I know what Capabilities a Solution has

	As an Authority User
	I want to add Capabilities to a Solution
	So that a Public user can discover what Capabilities a Solution has

Scenario: Authority Capabilities - Capabilities visible
Given that Capabilities have been provided for the Solution
When a User previews the Marketing Page
Then the Capability Name
And Capability Version
And Capability Description