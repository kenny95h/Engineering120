using AP_TestAutomationFramework.lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_TestAutomationFramework.tests
{
    public class AP_HomePage_Tests
    {
        private AP_Website<ChromeDriver> AP_Website = new();

        [Category("Search - Happy")]
        [Test]
        public void GivenIAmOnTheHomePage_WhenIDoASearch_ThenIShouldLandOnTheSearchResultsPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            Thread.Sleep(4000);
            AP_Website.AP_HomePage.SearchBox.SendKeys("ksdfhj");
            AP_Website.AP_HomePage.SearchBox.SendKeys(Keys.Enter);
            Thread.Sleep(4000);

            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Search - My Store"));
        }
    }
}
