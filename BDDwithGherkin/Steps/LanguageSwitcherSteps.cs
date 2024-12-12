using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace WebUi_automated_testing.Steps
{
    [Binding]
    public class LanguageSwitcherSteps
    {
        private readonly IWebDriver _driver;

        public LanguageSwitcherSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the user is on the homepage")]
        public void GivenTheUserIsOnTheHomepage()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
        }

        [When(@"the user clicks on the ""(.*)"" language link")]
        public void WhenTheUserClicksOnTheLanguageLink(string language)
        {
            var languageLink = _driver.FindElement(By.LinkText(language));
            languageLink.Click();
        }

        [Then(@"the user should be redirected to the Lithuanian version of the site")]
        public void ThenTheUserShouldBeRedirectedToTheLithuanianVersionOfTheSite()
        {
            _driver.Url.Should().Contain("https://lt.ehu.lt/", "User should be redirected to the Lithuanian site.");
        }

        [Then(@"the page header should contain ""(.*)""")]
        public void ThenThePageHeaderShouldContain(string expectedHeader)
        {
            var headerElement = _driver.FindElement(By.CssSelector("h1"));
            headerElement.Text.Should().Contain(expectedHeader, "Page header should contain the expected text.");
        }
    }
}