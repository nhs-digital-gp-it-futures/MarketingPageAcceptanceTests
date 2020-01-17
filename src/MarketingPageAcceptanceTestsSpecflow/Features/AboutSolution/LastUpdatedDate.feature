@ignore
Feature: Last Updated Date

	As an Authority User 
	I want to update content on a Marketing Page
	So that I can ensure content is correct

Scenario: Updated solution summary changes the last updated date
	Given that the Solution Summary is updated
	When the content has been updated
	Then the Last Changed Date is updated in the SolutionDetail table

Scenario: Updated about solution URL changes the last updated date
	Given that the About Solution URL is updated
	When the content has been updated
	Then the Last Changed Date is updated in the SolutionDetail table

Scenario: Updated contact details changes the last updated date
	Given that the Contact details are updated
	When the content has been updated
	Then the Last Changed Date is updated in the MarketingContact table