using NUnit.Framework;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMBDD.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public IWebDriver driver;
        //public int count;

        [AfterScenario]
        public void AfterScenario()
        {
            if(driver!=null)
            {
                driver.Quit();
            }
            
        }

      
    }
}
