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

        [Given(@"the user is on the contact page")]
        public void GivenTheUserIsOnTheContactPage()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");
        }

        [Then(@"the user should see the email ""(.*)"" on the page")]
        public void ThenTheUserShouldSeeTheEmailOnThePage(string expectedEmail)
        {
            Assert.IsTrue(_contactPage.GetPageSource().Contains(expectedEmail));
        }

        [Then(@"the user should see the phone number ""(.*)"" on the page")]
        public void ThenTheUserShouldSeeThePhoneNumberOnThePage(string expectedPhoneNumber)
        {
            Assert.IsTrue(_contactPage.GetPageSource().Contains(expectedPhoneNumber));
        }


        [AfterScenario]
        public void Cleanup()
        {
            DriverSingleton.QuitDriver();
        }
    }
}