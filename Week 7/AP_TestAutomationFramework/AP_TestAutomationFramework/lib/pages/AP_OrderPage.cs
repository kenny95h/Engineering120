using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_OrderPage
    {
        #region Properties
        private IWebDriver _seleniumDriver;
        private string _orderPageUrl = AppConfigReader.OrderPageUrl;
        //get only property
        private IWebElement _plusIcon => _seleniumDriver.FindElement(By.ClassName("icon-plus"));
        private IWebElement _total => _seleniumDriver.FindElement(By.Id("total_price"));
        private IWebElement _deleteBtn => _seleniumDriver.FindElement(By.ClassName("icon-trash"));
        private IWebElement _alert => _seleniumDriver.FindElement(By.ClassName("alert"));
        #endregion
        public AP_OrderPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitOrderPage() => _seleniumDriver.Navigate().GoToUrl(_orderPageUrl);
        public void IncreaseQuantity() => _plusIcon.Click();
        public string TotalPrice() => _total.Text;
        public void DeleteItem() => _deleteBtn.Click();
        public string AlertMessage() => _alert.Text;
        #endregion
    }
}
