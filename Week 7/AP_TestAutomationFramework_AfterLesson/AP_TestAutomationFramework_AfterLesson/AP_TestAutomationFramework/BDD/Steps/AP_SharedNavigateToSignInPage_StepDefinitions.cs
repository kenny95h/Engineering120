using AP_TestAutomationFramework.lib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]
namespace AP_TestAutomationFramework.BDD.Steps
{
    //[Binding]
    public class AP_SharedNavigateToSignInPage_StepDefinitions
    {
        public AP_Website<ChromeDriver> AP_Website { get; set; } = new AP_Website<ChromeDriver>();
        protected Credentials _credentials;

        [Given(@"I am on the signin page")]
        public void GivenIAmOnTheSigninPage()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
        }

        [AfterScenario]
        public void DiposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
        }
    }
}
