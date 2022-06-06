using Fujitsu.OrangeHRMBDD.Pages;
using Fujitsu.Utilities;
using OrangeHRMBDD.Hooks;
using System;
using TechTalk.SpecFlow;

namespace OrangeHRMBDD.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private AutomationHooks _hooks;
        private MainPage _main;

        public EmployeeStepDefinitions(AutomationHooks hooks)
        {
            this._hooks = hooks;
            InitPageObject();
        }
        public void InitPageObject()
        {
            //page object instantition 
            _main = new MainPage(_hooks.driver);W
        }

        [Given(@"I have browser with application")]
        public void GivenIHaveBrowserWithApplication()
        {
            
        }

        [When(@"I fill the record from excel '([^']*)' with sheetname '([^']*)'")]
        public void WhenIFillTheRecordFromExcelWithSheetname(string file, string sheetname)
        {
            string projectPath = Directory.GetCurrentDirectory();
            projectPath = projectPath.Remove(projectPath.IndexOf("bin"));
            object[] main=ExcelUtils.GetSheetIntoObjectArray(projectPath+file, sheetname);
            object[] row1 = (object[])main[0];
            Console.WriteLine(row1[0]);

            for(int i = 0; i < main.Length; i++)
            {
                object[] row = (object[])main[i];
                for(int j = 0; j < row.Length; j++)
                {
                    Console.WriteLine(row[j]);
                }
            }

            Console.WriteLine(main);
        }

        [Then(@"I should see the record in database")]
        public void ThenIShouldSeeTheRecordInDatabase()
        {
            
        }
    }
}
