Feature: DownloadAuthorityProvidedDataDocument
	As a Public User
	I want to download a document that contains Authority Provided Data
	So that I can view information about the Solution, its Associated and Additional Services

Scenario: Download Authority Provided Data Document - Download Attachment
	Given an Authority Provided Solution Document attachment has been provided for the Solution
	And a User previews the Marketing Page
	And the Learn more section is presented
	When the User chooses to download the Authority Provided Data Document
	Then the Authority Provided Data Document is downloaded
	And the attachment contains the Supplier's Authority Provided Data Document

Scenario: Download Authority Provided Data Document - Section not shown
	Given a Authority Provided Solution Document attachment has not been provided for the Solution
	When a User previews the Marketing Page
	Then the Learn more section is not presented
