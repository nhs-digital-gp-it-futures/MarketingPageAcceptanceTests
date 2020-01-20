﻿Feature: Suppliers - Edit Private Cloud Hosting Type
	As an Authority User
	I want to edit the Private Cloud Section
	So that I can make sure the information is correct

Scenario: Field does not exceed maximum
	Given the User has entered 500 characters on the Private cloud hosting page in the Private cloud section
	And I enter 1000 characters into the link field
	And I enter 1000 characters into the second text field
	When the User attempts to save 
	Then the Private cloud is saved

Scenario: Field does exceed maximum
	Given the User has entered 501 characters on the Private cloud hosting page in the Private cloud section
	And I enter 1001 characters into the link field
	And I enter 1001 characters into the second text field
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the User as to why

Scenario: Hosting Section marked as Complete -  Any Data Saved
	Given the Private cloud section does not require Mandatory Data
	And a User has saved any data in any field within Private cloud
	When the Marketing Page Form is presented 
	Then the Private cloud section is marked as Complete

Scenario: Hosting Type Section marked as Incomplete -  No Data
	Given the Private cloud section does not require Mandatory Data
	And a User has not saved any data on the Private cloud section
	When the Marketing Page Form is presented 
	Then the Private cloud section is marked as Incomplete

Scenario: Appear on Preview
	Given that Private cloud has been completed in the Hosting type section
	When a User previews the Marketing Page
	Then Summary will be presented in Private cloud on the Preview of the Marketing Page
	And The Private cloud section contains This Solution requires a HSCN/N3 connection on the preview of the marketing page

Scenario: HSCN/N3 connection does not appear on preview when not checked
	Given that Private cloud has been completed in the Hosting type section
	And the user unchecks the HSCN/N3 connection checkbox on the Private cloud section
	When a User previews the Marketing Page
	Then Summary will be presented in Private cloud on the Preview of the Marketing Page
	And The Private cloud section does not contain This Solution requires a HSCN/N3 connection on the preview of the marketing page