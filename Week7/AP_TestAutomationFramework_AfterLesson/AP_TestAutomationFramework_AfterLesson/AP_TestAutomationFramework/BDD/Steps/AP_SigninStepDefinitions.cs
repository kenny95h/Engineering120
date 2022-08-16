using AP_TestAutomationFramework.lib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using AP_TestAutomationFramework.BDD.Steps;



namespace AP_TestAutomationFramework.BDD.Features
{
    [Binding]
    [Scope(Feature = "AP_Signin")]
    public class AP_SigninStepDefinitions : AP_SharedNavigateToSignInPage_StepDefinitions
    {
        private Credentials _credentials;

        //This regular expression uses ([^""]*) to define parameters for the method.
        [Given(@"I have entered the email ""([^""]*)""")]
        public void GivenIHaveEnteredTheEmail(string email)
        {
            AP_Website.AP_SigninPage.InputEmailLogin(email);
        }

        [Given(@"I have entered the password ""([^""]*)""")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            AP_Website.AP_SigninPage.InputPasswordLogin(password);
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            AP_Website.AP_SigninPage.ClickSignin();
        }

        [When(@"I click the forgot your password\? link")]
        public void WhenIClickTheForgotYourPasswordLink()
        {
            AP_Website.AP_SigninPage.ClickForgotPasswordLink();
        }

        [Given(@"I have the following credentials:")]
        public void GivenIHaveTheFollowingCredentials(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
        }

        [When(@"enter these credentials")]
        public void WhenEnterTheseCredentials()
        {
            AP_Website.AP_SigninPage.InputSigninCredentials(_credentials);
        }

        [Then(@"I will go to a form to reset my password")]
        public void ThenIWillGoToAFormToResetMyPassword()
        {
            Assert.That(AP_Website.SeleniumDriver.Title, Is.EqualTo("Forgot your password - My Store"));
        }


        [Then(@"I should see an alert containing the error message ""([^""]*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string expected)
        {
            Assert.That(AP_Website.AP_SigninPage.GetAlertTextSignin(), Does.Contain(expected));
        }

    }
}
