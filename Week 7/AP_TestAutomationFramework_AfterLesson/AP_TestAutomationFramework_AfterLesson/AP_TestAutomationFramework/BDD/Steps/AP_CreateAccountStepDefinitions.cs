using AP_TestAutomationFramework.BDD.Steps;
using System;
using TechTalk.SpecFlow;

namespace AP_TestAutomationFramework.BDD.Steps
{
    [Binding]
    [Scope(Feature ="AP_CreateAccount")]
    public class AP_CreateAccountStepDefinitions : AP_SharedNavigateToSignInPage_StepDefinitions
    {
        [When(@"I enter the valid e-mail ""([^""]*)""")]
        public void WhenIEnterTheValidE_Mail(string email)
        {
            AP_Website.AP_SigninPage.InputEmailCreate(email);
        }

        [When(@"click create account")]
        public void WhenClickCreateAccount()
        {
            AP_Website.AP_SigninPage.ClickCreateButton();
        }

        [Then(@"I should appear on the create account page")]
        public void ThenIShouldAppearOnTheCreateAccountPage()
        {
            Thread.Sleep(5000);
            //Assert.That(AP_Website.AP_CreateAccountPage.GetUrl(), Does.Contain("account-creation"));
            Assert.That(AP_Website.AP_CreateAccountPage.GetCreateAccountPageHeadingTitle(), Is.EqualTo("create an account").IgnoreCase);
        }
    }
}
