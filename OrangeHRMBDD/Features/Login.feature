@login
Feature: Login
	In order to maintain employee records 
	As a admin 
	I want to access the portal 

	Background: 
	Given I have 'ch' browser with orangehrm application

@high 	@valid
Scenario: Valid Credential
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	Then I should get access to portal with url as 'https://opensource-demo.orangehrmlive.com/index.php/dashboard'
	
	@invalid @low
Scenario Outline: Invalid Credential
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	Then I should the message as 'Invalid credentials'
	Examples: 
	| username | password |
	| John     | John123  |
	| Peter    | Peter123 |
