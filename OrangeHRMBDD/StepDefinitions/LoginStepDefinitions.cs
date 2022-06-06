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
        private AutomationHooks _hooks;
        private LoginPage _login;
        private MainPage _main;

        public LoginStepDefinitions(AutomationHooks hooks)
        {
            this._hooks = hooks;
           // Console.WriteLine(hooks.count);
            //hooks.count = hooks.count + 10;
          //  Console.WriteLine(hooks.count);
        }

        //[Scope(Feature = "Login")]
        [Given(@"I have browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");
            _hooks.driver = new ChromeDriver();
            _hooks.driver.Manage().Window.Maximize();
            _hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _hooks.driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
           
            InitPageObject();
        }

        public void InitPageObject()
        {
            //page object instantition 
            _login = new LoginPage(_hooks.driver);
            _main = new MainPage(_hooks.driver);
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
