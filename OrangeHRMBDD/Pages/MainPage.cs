using OrangeHRMBDD.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeHRMBDD.Pages
{
    public class MainPage
    {
        private static By myInfoLocator = By.XPath("//*[text()='Mes Infos' or text()='My Info']");
        public string GetMainPageUrl()
        {
            return AutomationHooks.driver.Url;
        }

        public static void ClickOnMyInfo()
        {
            AutomationHooks.driver.FindElement(myInfoLocator).Click();
        }
    }
}
