using AP_TestAutomationFramework.lib.driver_config;
using AP_TestAutomationFramework.lib.pages;
using OpenQA.Selenium;

namespace AP_TestAutomationFramework.lib
{
    // Super class - essentially acting as a service object for all pages
    // i.e. decomposes objects into manageable classes and methods
    public class AP_Website<T> where T : IWebDriver, new()
    {
        #region Accessible age Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }
        public AP_HomePage AP_HomePage { get; set; }
        public AP_SigninPage AP_SigninPage { get; set; }
        public AP_CreateAccountPage AP_CreateAccountPage { get; set; }
        #endregion
        //Constructor for driver and config for teh service
        public AP_Website(int pageLoadInsecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            //instatiate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInsecs, implicitWaitInSecs, isHeadless).Driver;
            //instatiate our page objects with the selenium driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_SigninPage = new AP_SigninPage(SeleniumDriver);
            AP_CreateAccountPage = new AP_CreateAccountPage(SeleniumDriver);
        }
    }
}
