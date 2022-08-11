using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_HomePage
    {
        #region Properties
        private IWebDriver _seleniumDriver;
        private string _homePageUrl = AppConfigReader.BaseUrl;
        //get only property
        private IWebElement _signInLink => _seleniumDriver.FindElement(By.LinkText("Sign in"));
        private IWebElement _blouseItem => _seleniumDriver.FindElement(By.CssSelector("#homefeatured > .ajax_block_product:nth-child(2)"));
        private IWebElement _addBlouseBtn => _seleniumDriver.FindElement(By.CssSelector("#homefeatured > .ajax_block_product:nth-child(2) .button:nth-child(1) > span"));
        private IWebElement _proceedCheckoutBtn => _seleniumDriver.FindElement(By.CssSelector(".button-medium > span"));
        private IWebElement _searchBoxField => _seleniumDriver.FindElement(By.Id("search_query_top"));

        #endregion
        public AP_HomePage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void VisitSignInPage() => _signInLink.Click();
        public IWebElement GoToBlouse() => _blouseItem;
        public IWebElement SearchBox => _searchBoxField;
        public void AddBlouse() => _addBlouseBtn.Click();
        public void ProceedCheckout() => _proceedCheckoutBtn.Click();
        #endregion
    }
}
