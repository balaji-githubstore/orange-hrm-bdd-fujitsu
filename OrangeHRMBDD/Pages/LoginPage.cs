using OrangeHRMBDD.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//page object class
namespace Fujitsu.OrangeHRMBDD.Pages
{
    public class LoginPage
    {
        private static By _usernameLocator = By.Id("txtUsername");
        private static By _passwordLocator = By.CssSelector("#txtPassword");
        private static By _loginLocator = By.Id("btnLogin");
        private static By _errorLocator = By.Id("spanMessage");
        private static By _linkedinLocator = By.XPath("//*[contains(text(),'Link')]");

        public static void EnterUsername(string username)
        {
            AutomationHooks.driver.FindElement(_usernameLocator).SendKeys(username);
        }

        public static void EnterPassword(string password)
        {
            AutomationHooks.driver.FindElement(_passwordLocator).SendKeys(password);
        }

        public static void ClickOnLogin()
        {
            AutomationHooks.driver.FindElement(_loginLocator).Click();
        }

        public static string GetErrorMessage()
        {
            return AutomationHooks.driver.FindElement(_errorLocator).Text.Trim(); 
        }
        public static void ClickOnLinkedin()
        {
            AutomationHooks.driver.FindElement(_linkedinLocator).Click();
        }
    }
}
