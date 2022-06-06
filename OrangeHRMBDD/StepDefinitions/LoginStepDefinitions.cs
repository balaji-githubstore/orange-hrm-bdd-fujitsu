using NUnit.Framework;

using OpenQA.Selenium.Chrome;
using OrangeHRMBDD.Hooks;
using System;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMBDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Scope(Feature ="Login")]
        [Given(@"I have browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");
            AutomationHooks.driver = new ChromeDriver();
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AutomationHooks.driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            AutomationHooks.driver.FindElement(By.Id("txtUsername")).SendKeys(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            AutomationHooks.driver.FindElement(By.Id("txtPassword")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            AutomationHooks.driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Then(@"I should get access to portal with url as '([^']*)'")]
        public void ThenIShouldGetAccessToPortalWithUrlAs(string expectedUrl)
        {
            Assert.That(AutomationHooks.driver.Url, Is.EqualTo(expectedUrl));
        }


        [Then(@"I should the message as '([^']*)'")]
        public void ThenIShouldTheMessageAs(string expectedError)
        {
            string actualError = AutomationHooks.driver.FindElement(By.Id("spanMessage")).Text.Trim();
            Assert.That(actualError.Contains(expectedError), "Assertion on invalid error.");
        }

        [Scope(Feature ="Login")]
        [When(@"I enter mobile number as '([^']*)'")]
        public void WhenIEnterMobileNumberAs(string p0)
        {
            //login time - mobile
            //locator
        }


    }
}
