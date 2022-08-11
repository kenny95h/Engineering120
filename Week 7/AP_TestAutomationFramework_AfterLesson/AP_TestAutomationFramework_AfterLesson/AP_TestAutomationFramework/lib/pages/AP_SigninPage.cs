using OpenQA.Selenium;

namespace AP_TestAutomationFramework.lib.pages
{
    public class AP_SigninPage
    {
        #region Properties
        //Web driver
        private IWebDriver _seleniumDriver;
        //URL
        private string _signInPageUrl = AppConfigReader.SignInPageUrl;
        //Web elements
        private IWebElement _emailLoginField => _seleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordLoginField => _seleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement _signinButton => _seleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _signinAlert => _seleniumDriver.FindElement(By.ClassName("alert"));
        private IWebElement _forgotPasswordLink => _seleniumDriver.FindElement(By.LinkText("Forgot your password?"));
        private IWebElement _emailCreateField => _seleniumDriver.FindElement(By.Id("email_create"));
        private IWebElement _clickCreateButton => _seleniumDriver.FindElement(By.Id("SubmitCreate"));
        #endregion

        //Constructor
        public AP_SigninPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_signInPageUrl);
        public void InputEmailLogin(string email) => _emailLoginField.SendKeys(email);
        public void InputPasswordLogin(string password) => _passwordLoginField.SendKeys(password);
        public void ClickSignin() => _signinButton.Click();
        public string GetAlertTextSignin() => _signinAlert.Text;
        public void ClickForgotPasswordLink() => _forgotPasswordLink.Click();
        public void ClickCreateButton() => _clickCreateButton.Click();
        public void InputEmailCreate(string email) => _emailCreateField.SendKeys(email);


        public void InputSigninCredentials(Credentials credentials) 
        {
            _emailLoginField.SendKeys(credentials.Email);
            _passwordLoginField.SendKeys(credentials.Password); 
        }
        #endregion
    }
}
