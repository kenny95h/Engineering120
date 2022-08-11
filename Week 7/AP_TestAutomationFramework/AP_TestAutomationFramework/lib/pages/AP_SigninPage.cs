using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_SigninPage
    {
        #region Properties
        private IWebDriver _seleniumDriver;
        private string _signInPageUrl = AppConfigReader.SignInPageUrl;
        //get only property
        private IWebElement _emailField => _seleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement _submitbtn => _seleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _errorMsg => _seleniumDriver.FindElement(By.ClassName("alert"));
        private IWebElement _createEmail => _seleniumDriver.FindElement(By.Id("email_create"));
        private IWebElement _createAccAlert => _seleniumDriver.FindElement(By.Id("create_account_error"));
        private IWebElement _accountLink => _seleniumDriver.FindElement(By.Id("SubmitCreate"));
        #endregion
        public AP_SigninPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_signInPageUrl);
        public void InputEmail(string email) => _emailField.SendKeys(email);
        public void InputPassword(string password) => _passwordField.SendKeys(password);
        public void SubmitLogin() => _submitbtn.Click();
        public string ErrorMessage() => _errorMsg.Text;
        public void EnterCreateEmail(string email) => _createEmail.SendKeys(email);
        public string CreateAccAlert() => _createAccAlert.Text;
        public void CreateAccount() => _accountLink.Click();
        #endregion
    }
}
