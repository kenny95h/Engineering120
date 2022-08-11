using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_CreateAccountPage
    {
        private IWebDriver _seleniumDriver;
        public AP_CreateAccountPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        private IWebElement _createAccountPageHeadingTitle => _seleniumDriver.FindElement(By.ClassName("page-heading"));


        public string GetUrl() => _seleniumDriver.Url;
        public string GetCreateAccountPageHeadingTitle() => _createAccountPageHeadingTitle.Text;
    }
}
