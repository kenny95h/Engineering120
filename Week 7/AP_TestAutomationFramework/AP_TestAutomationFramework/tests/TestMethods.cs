using AP_TestAutomationFramework.lib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.tests
{
    public class TestMethods
    {
        
        public static void AddBlouseToOrder(AP_Website<ChromeDriver> AP_Website)
        {
            AP_Website.SeleniumDriver.Manage().Window.Maximize();
            AP_Website.AP_HomePage.VisitHomePage();
            Actions action = new Actions(AP_Website.SeleniumDriver);
            action.MoveToElement(AP_Website.AP_HomePage.GoToBlouse());
            action.Perform();
            Thread.Sleep(5000);
            AP_Website.AP_HomePage.AddBlouse();
            Thread.Sleep(5000);
            AP_Website.AP_HomePage.ProceedCheckout();
        }
    }
}
