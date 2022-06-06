using OrangeHRMBDD.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeHRMBDD.Pages
{
    public class LoginPage
    {
        private By _usernameLocator = By.Id("txtUsername");
        private By _passwordLocator = By.CssSelector("#txtPassword");
        private By _loginLocator = By.Id("btnLogin");
        private By _errorLocator = By.Id("spanMessage");
        private By _linkedinLocator = By.XPath("//*[contains(text(),'Link')]");

        public void EnterUsername(string username)
        {
            AutomationHooks.driver.FindElement(_usernameLocator).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            AutomationHooks.driver.FindElement(_passwordLocator).SendKeys(password);
        }

        public void ClickOnLogin()
        {
            AutomationHooks.driver.FindElement(_loginLocator).Click();
        }

        public string GetErrorMessage()
        {
            return AutomationHooks.driver.FindElement(_errorLocator).Text.Trim();
        }
        public void ClickOnLinkedin()
        {
            AutomationHooks.driver.FindElement(_linkedinLocator).Click();
        }
    }
}
