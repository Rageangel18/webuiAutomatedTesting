using NUnit.Framework;
using OpenQA.Selenium;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using FluentAssertions;
using Serilog;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    [Parallelizable]
    [Category("SearchPage")]
    public class SearchPageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: VerifySearchResults");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [TestCase("study programs", "https://en.ehu.lt/?s=study%20programs", "search-filter__result-count", "results found.")]
        public void VerifySearchResults(string searchTerm, string expectedUrl, string resultClass, string expectedText)
        {
            var searchPage = new SearchPage(_driver);

            Log.Information("Performing search with term: {SearchTerm}", searchTerm);
            searchPage.Search(searchTerm);

            Log.Information("Verifying the URL is: {ExpectedUrl}", expectedUrl);
            _driver.Url.Should().Be(expectedUrl, "because the search results should redirect to the correct URL.");

            Log.Information("Verifying the search results contain text: {ExpectedText}", expectedText);
            searchPage.GetResultText(resultClass).Should().Contain(expectedText, "because the result count message should contain the expected text.");
        }

        [TearDown]
        public void TearDown()
        {
            Log.Information("Test completed: VerifySearchResults");
            DriverSingleton.QuitDriver();
        }
    }
}