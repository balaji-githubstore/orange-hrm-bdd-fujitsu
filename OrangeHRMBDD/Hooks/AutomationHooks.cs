using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMBDD.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public IWebDriver driver;
        private FeatureContext featureContext;
        private ScenarioContext scenarioContext;
        private ISpecFlowOutputHelper helper;

        //public int count;

        public AutomationHooks(FeatureContext featureContext,ScenarioContext scenarioContext, ISpecFlowOutputHelper helper)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.helper = helper;
        }

        public void LaunchBrowser(string browser="ch")
        {
            switch (browser.ToLower())
            {
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case "ff":
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");
                    driver = new ChromeDriver();
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [AfterScenario]
        public void AfterScenario()
        {

            Console.WriteLine(scenarioContext.ScenarioInfo.Title);

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot= ts.GetScreenshot();
            screenshot.SaveAsFile("Image.png");

            helper.WriteLine("completed " + scenarioContext.ScenarioInfo.Title);
            helper.AddAttachment("Image.png");

            if (driver != null)
            {
                driver.Quit();
            }

        }


    }
}
