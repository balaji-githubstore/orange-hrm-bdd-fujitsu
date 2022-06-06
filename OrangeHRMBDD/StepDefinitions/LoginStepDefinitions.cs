using Fujitsu.OrangeHRMBDD.Pages;
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
        private LoginPage _login;
        private MainPage _main;

        [Scope(Feature = "Login")]
        [Given(@"I have browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");
            AutomationHooks.driver = new ChromeDriver();
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AutomationHooks.driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");

            InitPageObject();
        }

        public void InitPageObject()
        {
            //page object instantition 
            _login = new LoginPage();
            _main = new MainPage();
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            _login.EnterUsername(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            _login.EnterPassword(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            _login.ClickOnLogin();
        }

        [Then(@"I should get access to portal with url as '([^']*)'")]
        public void ThenIShouldGetAccessToPortalWithUrlAs(string expectedUrl)
        {
            Assert.That(_main.GetMainPageUrl(), Is.EqualTo(expectedUrl));
        }


        [Then(@"I should the message as '([^']*)'")]
        public void ThenIShouldTheMessageAs(string expectedError)
        {
            string actualError = _login.GetErrorMessage();
            Assert.That(actualError.Contains(expectedError), "Assertion on invalid error.");
        }



    }
}
