Feature: Search
	This functionality helps to check the search

@mytag
Scenario: Search Automation Testing
	Given I am on the page https://www.yahoo.com
	When I save the value "QATesting" with key "Testing"
	When I provide "Automation Testing" to locator "//input[@id='yschsp']
	When I click object "//button[@type='submit']"
	
Scenario: Search based on key
		Given I am on the page https://www.yahoo.com
		When I save the value "QATesting" with key "Testing"
		When I fetch value of key "Testing" and enter to locator "//input[@id='yschsp']
		When I click object "//button[@type='submit']"
	
	