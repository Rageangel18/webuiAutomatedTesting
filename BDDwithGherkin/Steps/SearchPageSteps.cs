using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;

namespace WebUi_automated_testing.Steps
{
    [Binding]
    public class SearchPageSteps
    {
        private readonly IWebDriver _driver;
        private SearchPage _searchPage;

        public SearchPageSteps()
        {
            _driver = DriverSingleton.GetDriver();
        }

        [Given(@"the user is on the Search Page homepage")]
        public void GivenTheUserIsOnTheSearchPageHomepage()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
            _searchPage = new SearchPage(_driver);
        }

        [When(@"the user searches for ""(.*)""")]
        public void WhenTheUserSearchesFor(string searchTerm)
        {
            _searchPage.PerformSearch(searchTerm);
        }

        [Then(@"the user should be redirected to ""(.*)""")]
        public void ThenTheUserShouldBeRedirectedTo(string expectedUrl)
        {
            _driver.Url.Should().Be(expectedUrl, "The user should be redirected to the expected search results page.");
        }

        [Then(@"the results count element with class ""(.*)"" should contain ""(.*)""")]
        public void ThenTheResultsCountElementWithClassShouldContain(string resultClass, string expectedText)
        {
            var resultText = _searchPage.GetResultCountText(resultClass);
            resultText.Should().Contain(expectedText, "The results count element should display the expected text.");
        }

        [AfterScenario]
        public void Cleanup()
        {
            DriverSingleton.QuitDriver();
        }
    }
}