using Fujitsu.OrangeHRMBDD.Pages;
using NUnit.Framework;

using OpenQA.Selenium.Chrome;
using OrangeHRMBDD.Hooks;
using System;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRMBDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions 
    {
        private AutomationHooks _hooks;
        private ScenarioContext _scenarioContext;
        private ISpecFlowOutputHelper helper;
        private LoginPage _login;
        private MainPage _main;

        public LoginStepDefinitions(AutomationHooks hooks,ScenarioContext scenarioContext, ISpecFlowOutputHelper helper)
        {
            this._hooks = hooks;
            this._scenarioContext = scenarioContext;
            this.helper = helper;
            // Console.WriteLine(hooks.count);
            //hooks.count = hooks.count + 10;
            //  Console.WriteLine(hooks.count);
        }

        //[Scope(Feature = "Login")]
        [Given(@"I have browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication()
        {

            _hooks.LaunchBrowser();
            InitPageObject();
        }
        [Given(@"I have '([^']*)' browser with orangehrm application")]
        public void GivenIHaveBrowserWithOrangehrmApplication(string browser)
        {
            _hooks.LaunchBrowser(browser);
            InitPageObject();
            helper.WriteLine("Page object initialized!!");
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
            //_scenarioContext.Add("username", username);
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
