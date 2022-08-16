using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumIntro
{
    public class Tests
    {

        [Ignore("Too Slow")]
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSignInLink_ThenILandOnTheSignInPage()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            using(IWebDriver driver = new ChromeDriver(options))
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the AP site
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                //Get Elements - grab the sign in link
                IWebElement signinLink = driver.FindElement(By.LinkText("Sign in"));
                signinLink.Click();
                //wait to ensure the response
                Thread.Sleep(5000);
                //Assert - that we have arrived on the sign in page
                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));
            }
        }

        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterea4DigitPassword_WhenIClickTheSignInButton_ThenIGetErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the sign in page
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                //Get Elements - email field and password field
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                //Input into fields
                emailField.SendKeys("nish@nish.com");
                passwordField.SendKeys("four");
                //Click submit button
                passwordField.SendKeys(Keys.Enter);
                //Get alert text for response
                IWebElement alert = driver.FindElement(By.ClassName("error-message-container"));
                //Assert - that we receive alert test
                Assert.That(alert.Text.Contains("sadface"));
            }
        }

        [Test]
        public void GivenIAmSignedInAndOnTheInventoryPage_AndIAddBackpackToCart_WhenIClickTheBasketButton_ThenIAmDisplayedTheBackpackInBasket()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the sign in page and then sign in
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("standard_user");
                passwordField.SendKeys("secret_sauce");
                passwordField.SendKeys(Keys.Enter);

                //Get Element - add backpack to cart button and basket button
                IWebElement addBackpack = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
                IWebElement basket = driver.FindElement(By.ClassName("shopping_cart_link"));
                //Click buttons to add to basket and go to basket
                addBackpack.Click();
                basket.Click();
                //Get inventory element
                IWebElement inventory = driver.FindElement(By.ClassName("inventory_item_name"));
                Thread.Sleep(3000);
                //Assert - that we receive alert test
                Assert.That(inventory.Text, Is.EqualTo("Sauce Labs Backpack"));
            }
        }

        [Test]
        public void GivenIAmSignedInAndOnTheCheckoutPage_AndLeaveFieldsEmpty_WhenIClickContinue_ThenIGetErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the sign in page and sign in, then navigate to checkout
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                IWebElement emailField = driver.FindElement(By.Id("user-name"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                emailField.SendKeys("standard_user");
                passwordField.SendKeys("secret_sauce");
                passwordField.SendKeys(Keys.Enter);
                driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-step-one.html");
                //Get Element - add backpack to cart button and basket button
                IWebElement continuebtn = driver.FindElement(By.Id("continue"));
                //Click buttons to continuet
                continuebtn.Click();
                //Get alert text for response
                IWebElement alert = driver.FindElement(By.ClassName("error-message-container"));
                Thread.Sleep(3000);
                //Assert - that we receive alert test
                Assert.That(alert.Text.Contains("Error:"));
            }
        }

        [Test]
        public void cookies()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                //navigate to the sign in page and sign in, then navigate to checkout
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                driver.Manage().Cookies.DeleteAllCookies();
                Thread.Sleep(3000);
                DateTime time = new DateTime(2022, 08, 11, 11, 33, 04);
                Cookie cookie = new Cookie("session-username", "standard_user", "www.saucedemo.com", "/", time);
                driver.Manage().Cookies.AddCookie(cookie);
                driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
                Thread.Sleep(100000);
            
            }
        }

        [Test]
        public void GivenIAmOnTheDragAndDropPage_WhenIDragBoxAToBoxB_ThenTheBoxesHaveSwitchedPositions()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the drag and drop page<header>A</header>
                driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
                //Get Element - get box positions
                IWebElement columnA = driver.FindElement(By.Id("draggable"));
                IWebElement columnB = driver.FindElement(By.Id("droppable"));
                IWebElement output = driver.FindElement(By.Id("droppable")).FindElement(By.TagName("p"));
                ////Drag and drop item
                Actions action = new Actions(driver);
                action.DragAndDrop(columnA, columnB).Perform();
                Thread.Sleep(3000);
                //Assert - that box has changed
                Assert.That(output.Text, Is.EqualTo("Dropped!"));
            }
        }
        [Test]
        public void test()
        { 
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate to the AP site
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                //Get Elements - grab the sign in link
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.CssSelector("#homefeatured > .ajax_block_product:nth-child(2)")));
                action.Perform();
                action.MoveToElement(driver.FindElement(By.CssSelector("#homefeatured > .ajax_block_product:nth-child(2) .button:nth-child(1) > span")));
                action.Click().Perform();
                //wait to ensure the response
                Thread.Sleep(10000);
                driver.FindElement(By.CssSelector(".button-medium > span")).Click();
                Thread.Sleep(3000);
                //Assert - that we have arrived on the sign in page
                Assert.That(driver.Title, Is.EqualTo("Order - My Store"));
            }
        }
    }
}