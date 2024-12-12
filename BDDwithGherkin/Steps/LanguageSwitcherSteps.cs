using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;

namespace WebUi_automated_testing.Steps
{
    [Binding]
    public class LanguageSwitcherSteps
    {
        private readonly IWebDriver _driver;
        private LanguageSwitcherPage _languageSwitcherPage;

        public LanguageSwitcherSteps(IWebDriver driver)
        {
            _driver = driver;
            _languageSwitcherPage = new LanguageSwitcherPage(_driver);
        }

        [Given(@"the user is on the homepage")]
        public void GivenTheUserIsOnTheHomepage()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
        }

 
        [When(@"the user clicks on the ""(.*)"" language link")]
        public void WhenTheUserClicksOnTheLanguageLink(string language)
        {
            _languageSwitcherPage.SwitchToLithuanianLanguage(); 
        }

        [Then(@"the user should be redirected to the Lithuanian version of the site")]
        public void ThenTheUserShouldBeRedirectedToTheLithuanianVersionOfTheSite()
        {
            _driver.Url.Should().Contain("https://lt.ehu.lt/", "User should be redirected to the Lithuanian site.");
        }


        [AfterScenario]
        public void Cleanup()
        {
            DriverSingleton.QuitDriver();
        }
    }
}