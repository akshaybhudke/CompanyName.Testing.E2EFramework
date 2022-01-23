Feature: Login
	Simple login scenarios added to test


Scenario: Login as a valid user
	Given I navigate to landing page
	When I entered valid username as 'TestUser'
	And I entered valid password
	Then I should see welcome page