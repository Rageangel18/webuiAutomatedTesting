using NUnit.Framework;
using TechTalk.SpecFlow;
using WebUi_automated_testing.PageObjects;
using OpenQA.Selenium;
using WebUi_automated_testing.Utilities;

namespace WebUi_automated_testing.Steps
{
    [Binding]
    public class ContactPageSteps
    {
        private readonly IWebDriver _driver;
        private ContactPage _contactPage;

        public ContactPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _contactPage = new ContactPage(_driver);
        }

        [Given(@"the user navigates to ""(.*)""")]
        public void GivenTheUserNavigatesTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the user should see the contact information ""(.*)""")]
        public void ThenTheUserShouldSeeTheContactInformation(string expectedText)
        {
            Assert.IsTrue(_contactPage.GetPageSource().Contains(expectedText), $"Expected text '{expectedText}' not found on the page.");
        }

        [AfterScenario]
        public void Cleanup()
        {
            DriverSingleton.QuitDriver();
        }
    }
}