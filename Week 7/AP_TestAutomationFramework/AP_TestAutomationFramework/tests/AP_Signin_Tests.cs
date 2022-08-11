using AP_TestAutomationFramework.lib;
using OpenQA.Selenium.Chrome;

namespace AP_TestAutomationFramework.tests
{
    public class Tests
    {
        private AP_Website<ChromeDriver> AP_Website = new();

        [Category("Sign In - Happy")]
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSignInButton_ThenIShouldLandOnTheSignInPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Login - My Store"));
        }

        [Category("Sign In - Sad")]
        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterAFourDigitPassword_WhenIClickTheSignInButton_ThenIGetAnError()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
            AP_Website.AP_SigninPage.InputEmail(AppConfigReader.EmailSignIn);
            AP_Website.AP_SigninPage.InputPassword("four");
            AP_Website.AP_SigninPage.SubmitLogin();
            Assert.That(AP_Website.AP_SigninPage.ErrorMessage().Contains("Invalid password"));
        }

        [Category("Sign In - Happy")]
        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterTheCorrectEmailAndPassword_WhenIClickTheSignInButton_ThenIShouldLandOnTheAccountPage()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
            AP_Website.AP_SigninPage.InputEmail(AppConfigReader.EmailSignIn);
            AP_Website.AP_SigninPage.InputPassword(AppConfigReader.PasswordSignIn);
            AP_Website.AP_SigninPage.SubmitLogin();
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("My account - My Store"));
        }

        [Category("Create Account - Happy")]
        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterAValidEmailAddress_WhenIClickTheCreateButton_ThenIShouldLandOnSignUpPage()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
            Thread.Sleep(5000);
            AP_Website.AP_SigninPage.EnterCreateEmail("newaccount@email.com");
            Thread.Sleep(5000);
            AP_Website.AP_SigninPage.CreateAccount();
            Thread.Sleep(5000);
            Assert.That(AP_Website.SeleniumDriver.Url, Does.Contain("account-creation"));
        }



        [Category("Create Account - Sad")]
        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterAnInvalidEmailAddress_WhenIClickTheCreateButton_ThenIShouldGetAnErrorMessage()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
            Thread.Sleep(5000);
            AP_Website.AP_SigninPage.EnterCreateEmail("RonDeSantis");
            Thread.Sleep(5000);
            AP_Website.AP_SigninPage.CreateAccount();
            Thread.Sleep(5000);
            Assert.That(AP_Website.AP_SigninPage.CreateAccAlert(), Does.Contain("Invalid email address"));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}