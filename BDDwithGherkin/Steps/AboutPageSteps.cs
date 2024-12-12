using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;

namespace WebUi_automated_testing.Steps
{
    [Binding]
    public class AboutPageSteps
    {
        private readonly IWebDriver _driver;
        private AboutPage _aboutPage;

        public AboutPageSteps()
        {
            _driver = DriverSingleton.GetDriver();
        }

        [Given(@"the user is on the About Page homepage")]
        public void GivenTheUserIsOnTheAboutPageHomepage()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
            _aboutPage = new AboutPage(_driver);
        }

        [When(@"the user clicks on the ""(.*)"" link")]
        public void WhenTheUserClicksOnTheLink(string linkText)
        {
            linkText.Should().Be("About");
            _aboutPage.ClickAbout();
        }

        [Then(@"the user should be redirected to the ""(.*)"" page")]
        public void ThenTheUserShouldBeRedirectedToThePage(string expectedPage)
        {
            expectedPage.Should().Be("About");
            _driver.Url.Should().Contain("about", "The URL should contain 'about' to indicate redirection.");
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            _driver.Title.Should().Be(expectedTitle, "The page title should match the expected title.");
        }

        [AfterScenario]
        public void Cleanup()
        {
            DriverSingleton.QuitDriver();
        }
    }
}