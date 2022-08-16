using AP_TestAutomationFramework.lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.tests
{
    public class AP_Checkout_Tests
    {
        private AP_Website<ChromeDriver> AP_Website = new();

        [Category("Checkout - Happy")]
        [Test]
        public void GivenIAmOnTheHomePage_WhenIAddABlouseToTheBasket_AndFollowTheProceedToCheckoutPopup_ThenIShouldLandOnTheCheckout()
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
            Thread.Sleep(5000);
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Order - My Store"));
        }

        [Category("Checkout - Happy")]
        [Test]
        public void GivenIAmOnTheOrderPage_AndIHaveOneBlouseInTheBasket_WhenIIncreaseTheQuantityByTwo_ThenIAmDisplayedTheCorrectTotal()
        {
            // Add Item to cart and go to order page
            TestMethods.AddBlouseToOrder(AP_Website);

            //AP_Website.AP_OrderPage.VisitOrderPage();
            //AP_Website.SeleniumDriver.Manage().Cookies.DeleteAllCookies();
            //Thread.Sleep(3000);
            //DateTime time = new DateTime(2022, 08, 31, 10, 00, 04);
            //Cookie cookie = new Cookie("PrestaShop-a30a9934ef476d11b6cc3c983616e364", "iJZ0%2BwRebP0Y5skyN%2FLUsg9DVKfEYDn0hXZjDr2fbF8ZubxAvDR45t%2FV2xz9HgZVA2nt2gG1g%2F52jPmEsQg%2FhBK%2FJsXleALK9GXvMrfT8onMMOFXlU8baXqY3y0%2F3hz73GD9%2ByETmGGC%2FAuTXbUSIDcel1LHOsWyGx1BJXQh8QXjdzOrjRmQ4AFl8wBLg9J2000136", ".automationpractice.com", "/", time);
            //AP_Website.SeleniumDriver.Manage().Cookies.AddCookie(cookie);
            //Thread.Sleep(100000);

            //Increase quantity
            AP_Website.AP_OrderPage.IncreaseQuantity();
            Thread.Sleep(3000);
            AP_Website.AP_OrderPage.IncreaseQuantity();
            Thread.Sleep(3000);
            Assert.That(AP_Website.AP_OrderPage.TotalPrice(), Is.EqualTo("$83.00"));

        }

        [Category("Checkout - Happy")]
        [Test]
        public void GivenIAmOnTheOrderPage_AndIHaveOneBlouseInTheBasket_WhenIDeleteTheItem_ThenIGetBasketEmptyMessage()
        {
            // Add Item to cart and go to order page
            TestMethods.AddBlouseToOrder(AP_Website);

            //
            AP_Website.AP_OrderPage.DeleteItem();
            Thread.Sleep(3000);
            Assert.That(AP_Website.AP_OrderPage.AlertMessage().Contains("empty"));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
