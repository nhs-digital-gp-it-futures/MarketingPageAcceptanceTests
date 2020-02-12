Feature: Supplier Data - Download Roadmap Attachment
	As a Public User
	I want to download a Roadmap attachment
	So that I can view the Roadmap attachment

#Techdebt 4898
#@ignore 
Scenario: Download Roadmap Attachment - Download Attachment
	Given a Roadmap attachment has been provided for the Solution
	And a User previews the Marketing Page
	And the Roadmap section is presented
	When the User chooses to download the Roadmap attachment
	#Then the attachment is downloaded
	#And the attachment contains the Supplier's Roadmap

Scenario: Download Roadmap Attachment - No File
	Given a solution has been created with all data complete
	And a Roadmap attachment has not been provided for the Solution
	When a User previews the Marketing Page
	Then there is no call to action to download a file in the Roadmap section

Scenario: Download Roadmap Attachment - Section not shown
	Given a Roadmap attachment has not been provided for the Solution
	When a User previews the Marketing Page
	Then the Roadmap section is not presented
