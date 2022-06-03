using NUnit.Framework;

using OpenQA.Selenium.Chrome;
using System;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMBDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;

        [Given(@"I have browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Then(@"I should get access to portal with url as '([^']*)'")]
        public void ThenIShouldGetAccessToPortalWithUrlAs(string expectedUrl)
        {
            Assert.That(driver.Url, Is.EqualTo(expectedUrl));
        }


        [Then(@"I should the message as '([^']*)'")]
        public void ThenIShouldTheMessageAs(string expectedError)
        {
            string actualError=driver.FindElement(By.Id("spanMessage")).Text.Trim();
            Assert.That(actualError.Contains(expectedError),"Assertion on invalid error.");
        }



    }
}
