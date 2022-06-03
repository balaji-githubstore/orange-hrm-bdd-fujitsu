using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMBDD.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public static IWebDriver driver;

        [AfterScenario]
        public void AfterScenario()
        {
            AutomationHooks.driver.Quit();
        }
    }
}
