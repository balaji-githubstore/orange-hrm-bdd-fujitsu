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
        public static IWebDriver driver;

        [AfterScenario]
        public void AfterScenario()
        {
            if(AutomationHooks.driver!=null)
            {
                AutomationHooks.driver.Quit();
            }
            
        }

      
    }
}
