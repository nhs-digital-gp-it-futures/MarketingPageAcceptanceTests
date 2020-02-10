Feature: Supplier Data - Download NHS Assured Integrations Attachment
	As a Public User
	I want to download an NHS Assured Integrations attachment
	So that I can view the NHS Assured Integrations attachment

#Techdebt 4898
@ignore 
Scenario: Download Integrations Attachment - Download Attachment
	Given an NHS Assured Integrations attachment has been provided for the Solution
	And a User previews the Marketing Page
	And the Integrations section is presented
	When the User chooses to download the attachment
	Then the attachment is downloaded
	And the attachment contains the Supplier's NHS Assured Integrations

Scenario: Download Integrations Attachment - No File
	Given a solution has been created with all data complete
	And a Integrations attachment has not been provided for the Solution
	When a User previews the Marketing Page
	Then there is no call to action to download a file in the Integrations section

Scenario: Download Integrations Attachment - Section not shown
	Given a Integrations attachment has not been provided for the Solution
	When a User previews the Marketing Page
	Then the Integrations section is not presented