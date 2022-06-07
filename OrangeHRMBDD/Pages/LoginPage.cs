using Fujitsu.Hooks;
using OrangeHRMBDD.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeHRMBDD.Pages
{
    public class LoginPage : WebDriverKeywords
    {
        private By _usernameLocator = By.Id("txtUsername");
        private By _passwordLocator = By.CssSelector("#txtPassword");
        private By _loginLocator = By.Id("btnLogin");
        private By _errorLocator = By.Id("spanMessage");
        private By _linkedinLocator = By.XPath("//*[contains(text(),'Link')]");

        private IWebDriver _driver;
        public LoginPage(IWebDriver driver):base(driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            EnterUsingLocator(_usernameLocator, username);
        }

        public void EnterPassword(string password)
        {
            EnterUsingLocator(_passwordLocator, password);
        }

        public void ClickOnLogin()
        {
            ClickUsingLocator(_loginLocator);
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(_errorLocator).Text.Trim();
        }
        public void ClickOnLinkedin()
        {
            _driver.FindElement(_linkedinLocator).Click();
        }
    }
}
