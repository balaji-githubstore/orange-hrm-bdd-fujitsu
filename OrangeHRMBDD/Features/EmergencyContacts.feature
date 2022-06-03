Feature: EmergencyContacts
In order to maintain the emergency contacts 
As a admin
I should be able to add,edit,delete the emergency contacts


Scenario Outline: Add Emergency Contact
	Given I have browser with orangehrm application
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	And I click on My Info
	And I click on Emergency Contact
	And I click add emergency contact
	And I fill the form
		| contactname   | relationship   | hometelephone | mobile   | worktelephone |
		| <contactname> | <relationship> | <homephone>   | <mobile> | <workphone>   |
	And I click on save
	Then I should get the added contact details in the assigned contact table
Examples:
	| username | password | contactname | relationship | homephone | mobile | workphone |
	| Admin    | admin123 | Sathish     | Brother      | 4554      | 5553   | 454554    |
	| Admin    | admin123 | Paul        | Father       | 45541     | 55531  | 4545541   |

