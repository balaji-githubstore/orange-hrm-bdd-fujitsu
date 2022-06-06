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
            AutomationHooks.driver.Quit();
        }

        [Given(@"I have browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication()
        {
            new DriverManager().SetUpDriver(new EdgeConfig(), version: "99.0.4844.51");
            AutomationHooks.driver = new EdgeDriver();
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AutomationHooks.driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }
    }
}
