using NUnit.Framework;
using OrangeHRMBDD.Hooks;
using System;
using TechTalk.SpecFlow;

namespace OrangeHRMBDD.StepDefinitions
{
    [Binding]
    public class EmergencyContactsStepDefinitions
    {
        private static Table _table;

        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            //AutomationHooks.driver.FindElement(By.XPath("My Info")).Click();
            AutomationHooks.driver.FindElement(By.XPath("//*[text()='Mes Infos' or text()='My Info']")).Click();
        }

        [When(@"I click on Emergency Contact")]
        public void WhenIClickOnEmergencyContact()
        {
            //  AutomationHooks.driver.FindElement(By.LinkText("Emergency Contacts")).Click();
            AutomationHooks.driver.FindElement(By.XPath("//*[text()=\"Contacter en cas d'urgence\" or text()='Emergency Contacts']")).Click();
        }

        [When(@"I click add emergency contact")]
        public void WhenIClickAddEmergencyContact()
        {
            AutomationHooks.driver.FindElement(By.Id("btnAddContact")).Click();   
        }

        [When(@"I fill the form")]
        public void WhenIFillTheForm(Table table)
        {
            _table = table;
            Console.WriteLine(table.Rows[0][0]);
            Console.WriteLine(table.Rows[0][1]);
            Console.WriteLine(table.Rows[0]["contactname"]);
            Console.WriteLine(table.Rows[0]["relationship"]);
            Console.WriteLine(table.RowCount);

            string contactName = table.Rows[0]["contactname"];
            string relationship = table.Rows[0]["relationship"];
            string homeTelephone= table.Rows[0]["hometelephone"];
            string mobile= table.Rows[0]["mobile"];
            //string workTelephone = table.Rows[0]["worktelephone"];

            AutomationHooks.driver.FindElement(By.Id("emgcontacts_name")).SendKeys(contactName);
            AutomationHooks.driver.FindElement(By.Id("emgcontacts_relationship")).SendKeys(relationship);
            AutomationHooks.driver.FindElement(By.Id("emgcontacts_homePhone")).SendKeys(homeTelephone);
            AutomationHooks.driver.FindElement(By.Id("emgcontacts_mobilePhone")).SendKeys(mobile);
            AutomationHooks.driver.FindElement(By.Id("emgcontacts_workPhone")).SendKeys(table.Rows[0]["worktelephone"]);
            
        }

        [When(@"I click on save")]
        public void WhenIClickOnSave()
        {
            AutomationHooks.driver.FindElement(By.Id("btnSaveEContact")).Click();
        }

        [Then(@"I should get the added contact details in the assigned contact table")]
        public void ThenIShouldGetTheAddedContactNameInTheAssignedContactTable()
        {
            string tableData = AutomationHooks.driver.FindElement(By.Id("emgcontact_list")).Text;
            Console.WriteLine(tableData);
            Assert.That(tableData.Contains(_table.Rows[0]["contactname"])); //expect true
        }
    }
}
