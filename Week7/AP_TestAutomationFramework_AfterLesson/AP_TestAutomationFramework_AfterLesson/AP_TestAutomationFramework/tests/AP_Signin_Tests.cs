//using AP_TestAutomationFramework.lib;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;

//namespace AP_TestAutomationFramework.tests
//{
//    public class Tests
//    {
//        private AP_Website<ChromeDriver> AP_Website = new();

//        [Test]
//        public void GivenIAmOnTheHomePage_WhenIClickTheSIgninButton_ThenIShouldLandOnTheSignInPage()
//        {
//            AP_Website.AP_HomePage.VisitHomePage();
//            AP_Website.AP_HomePage.VisitSignInPage();
//            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Login - My Store"));
//        }
//        [Test]
//        public void GivenIAmOnTheSigninPage_AndIEnterA4DigitPassword_WhenIClickTheSignInButton_ThenIGetAnErrorMessage()
//        {
//            //Navigate to signin page
//            AP_Website.AP_SigninPage.VisitSignInPage();
//            //Input email address
//            AP_Website.AP_SigninPage.InputEmailLogin("testing@snailmail.ccm");
//            //Input password
//            AP_Website.AP_SigninPage.InputPasswordLogin("four");
//            //Click the signin Button
//            AP_Website.AP_SigninPage.ClickSignin();
//            //Assert that the resultant error message contains the string "Invalid password"
//            Assert.That(AP_Website.AP_SigninPage.GetAlertTextSignin().Contains("Invalid password."));
//        }
//        [OneTimeTearDown]
//        public void CleanUp()
//        {
//            AP_Website.SeleniumDriver.Quit();
//            AP_Website.SeleniumDriver.Dispose();
//        }
//    }
//}