using AP_TestAutomationFramework.lib.driver_config;
using AP_TestAutomationFramework.lib.pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib
{
    // Super class - essentially acting as a service object for all pages
    // Decomposes objects into manageable classes and methods
    public class AP_Website<T> where T : IWebDriver, new()
    {
        #region accessible page objects and selenium driver
        public IWebDriver SeleniumDriver { get; set; }
        public AP_HomePage AP_HomePage { get; set; }
        public AP_SigninPage AP_SigninPage { get; set; }
        public AP_OrderPage AP_OrderPage { get; set; }
        #endregion
        //Constructor for driver and config for the service
        public AP_Website(int pageLoadInSecs = 20, int implicitWaitInSecs = 20, bool isHeadless = false)
        {
            //Instantiate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            //Instantiate our Page Objects with the selenium driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_SigninPage = new AP_SigninPage(SeleniumDriver);
            AP_OrderPage = new AP_OrderPage(SeleniumDriver);
        }
    }
}
