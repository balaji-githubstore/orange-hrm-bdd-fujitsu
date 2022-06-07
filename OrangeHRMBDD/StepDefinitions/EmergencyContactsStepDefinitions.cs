using Fujitsu.OrangeHRMBDD.Pages;
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
        private AutomationHooks _hooks;
        private ScenarioContext _scenarioContext;
        private MainPage _main;
        private MyInfoPage _info;

        public EmergencyContactsStepDefinitions(AutomationHooks hooks, ScenarioContext scenarioContext)
        {
            this._hooks = hooks;
            this._scenarioContext = scenarioContext;
            //Console.WriteLine(_hooks.count);
            InitPageObject();

        }

        public void InitPageObject()
        {
            //page object instantition 
            _main = new MainPage(_hooks.driver);
            _info = new MyInfoPage(_hooks.driver);
        }

        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            _main.ClickOnMyInfo();
        }

        [When(@"I click on Emergency Contact")]
        public void WhenIClickOnEmergencyContact()
        {
            //  AutomationHooks.driver.FindElement(By.LinkText("Emergency Contacts")).Click();
            _hooks.driver.FindElement(By.XPath("//*[text()=\"Contacter en cas d'urgence\" or text()='Emergency Contacts']")).Click();
        }

        [When(@"I click add emergency contact")]
        public void WhenIClickAddEmergencyContact()
        {
            _hooks.driver.FindElement(By.Id("btnAddContact")).Click();   
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
            //string email=table.Rows[0]["email"];

            _hooks.driver.FindElement(By.Id("emgcontacts_name")).SendKeys(contactName);
            _hooks.driver.FindElement(By.Id("emgcontacts_relationship")).SendKeys(relationship);
            _hooks.driver.FindElement(By.Id("emgcontacts_homePhone")).SendKeys(homeTelephone);
            _hooks.driver.FindElement(By.Id("emgcontacts_mobilePhone")).SendKeys(mobile);
            _hooks.driver.FindElement(By.Id("emgcontacts_workPhone")).SendKeys(table.Rows[0]["worktelephone"]);
            
        }

        [When(@"I click on save")]
        public void WhenIClickOnSave()
        {
            _hooks.driver.FindElement(By.Id("btnSaveEContact")).Click();
        }

        [Then(@"I should get the added contact details in the assigned contact table")]
        public void ThenIShouldGetTheAddedContactNameInTheAssignedContactTable()
        {
            //if(_scenarioContext.TryGetValue("username", out string value))
            //{
            //    Console.WriteLine(value);
            //}
            //else
            //{
            //    Console.WriteLine("no key avaialble");
            //}


            string tableData = _hooks.driver.FindElement(By.Id("emgcontact_list")).Text;
            Console.WriteLine(tableData);
            Assert.That(tableData.Contains(_table.Rows[0]["contactname"])); //expect true
        }   
    }
}
