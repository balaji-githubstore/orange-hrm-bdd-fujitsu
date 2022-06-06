using Fujitsu.Utilities;
using System;
using TechTalk.SpecFlow;

namespace OrangeHRMBDD.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
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
