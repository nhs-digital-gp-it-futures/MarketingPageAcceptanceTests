Feature: Suppliers - Edit Native Mobile or Tablet - Memory and Storage
	As an Authority User
	I want to edit the Memory and Storage Sub-Section
	So that I can make sure the information is correct

Background:
	Given the user has set Native mobile or tablet application type

Scenario: Native Mobile or Tablet Memory and Storage - Mandatory - Yes
	Given the User has entered 300 characters for Memory and storage section on Native mobile or tablet sub dashboard
	And the User selects a memory requirement
	When the User attempts to save
	Then the Memory and storage section is marked as COMPLETE on the Browser Based Client Type Sub-Form

Scenario: Native Mobile or Tablet Memory and Storage - Data not Saved
	Given that an answer has not been provided to the Memory and storage mandatory question on the Native mobile or tablet section
	When the User exits the page
	Then on the Native mobile or tablet dashboard
	And the Memory and storage section is marked as INCOMPLETE on the Browser Based Client Type Sub-Form

Scenario: Native Mobile or Tablet Memory and Storage - Does not exceed maximum
	Given the User has entered 300 characters for Memory and storage section on Native mobile or tablet sub dashboard
	And the User selects a memory requirement
	When the User attempts to save 
	Then the Memory and storage is saved

Scenario: Native Mobile or Tablet Memory and Storage - Does exceed maximum
	Given the User has entered 301 characters for Memory and storage section on Native mobile or tablet sub dashboard
	And the User selects a memory requirement
	When the User attempts to save 
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Native Mobile or Tablet Memory and Storage - Mandatory Data Missing Validation
	Given the User has entered 300 characters for Memory and storage section on Native mobile or tablet sub dashboard
	When the User attempts to save
	Then the Section is not saved 
	And an indication is given to the Supplier as to why

Scenario: Native Mobile or Tablet Memory and Storage - Validation Error Message Anchors
	Given validation has been triggered on Native mobile or tablet section Memory and storage
	When the User selects an error link in the Error Summary
	Then the User will be navigated to the relevant section on the page
