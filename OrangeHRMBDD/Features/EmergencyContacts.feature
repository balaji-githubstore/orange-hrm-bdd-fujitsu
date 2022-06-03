Feature: EmergencyContacts
In order to maintain the emergency contacts 
As a admin
I should be able to add,edit,delete the emergency contacts


Scenario: Add Emergency Contact
Given I have browser with orangehrm application
When I enter username as 'Admin'
And I enter password as 'admin123'
And I click on login
And I click on My Info
And I click on Emergency Contact
And I click add emergency contact
And I fill the form
| contactname | relationship | hometelephone | mobile    | worktelephone |
| Sathish     | Brother      | 8787878       | 878888989 | 878898        |
And I click on save
Then I should get the added contact name in the assigned contact table


