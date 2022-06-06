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
        private By myInfoLocator = By.XPath("//*[text()='Mes Infos' or text()='My Info']");

        private IWebDriver _driver;
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public string GetMainPageUrl()
        {
            return _driver.Url;
        }

        public void ClickOnMyInfo()
        {
            _driver.FindElement(myInfoLocator).Click();
        }
    }
}
