Feature: Login
	In order to maintain employee records 
	As a admin 
	I want to access the portal 


Scenario: Valid Credential
	Given I have browser with orangehrm application
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	Then I should get access to portal with url as 'https://opensource-demo.orangehrmlive.com/index.php/dashboard'

Scenario: Invalid Credential
	Given I have browser with orangehrm application
	When I enter username as 'John'
	And I enter password as 'john123'
	And I click on login
	Then I should the message as 'Invalid credentials'