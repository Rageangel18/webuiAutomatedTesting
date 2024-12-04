using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;
using FluentAssertions;
using Serilog;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase2 : IDisposable
    {
        private readonly IWebDriver _driver;

        public TestCase2()
        {
            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: SearchPageTest");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [Theory]
        [InlineData("https://en.ehu.lt/", "study programs", "https://en.ehu.lt/?s=study%20programs", "search-filter__result-count", "results found.")]
        public void SearchPageTest(string url, string searchTerm, string expectedUrl, string resultClass, string expectedText)
        {

            Log.Information("Navigating to URL: {Url}", url);
            _driver.Navigate().GoToUrl(url);

            var searchUrl = $"{url}?s={Uri.EscapeDataString(searchTerm)}";
            Log.Information("Performing search with query: {SearchTerm} -> URL: {SearchUrl}", searchTerm, searchUrl);
            _driver.Navigate().GoToUrl(searchUrl);


            Log.Information("Verifying the URL is: {ExpectedUrl}", expectedUrl);
            _driver.Url.Should().Be(expectedUrl, "because the search URL should match the expected URL");

            var searchPage = new SearchPage(_driver);
            Log.Information("Verifying search result contains: {ExpectedText}", expectedText);
            searchPage.SearchResultCount(resultClass).Text.Should().Contain(expectedText, "because the search results should contain the expected text.");
        }

        public void Dispose()
        {
            Log.Information("Test completed: SearchPageTest");
            DriverSingleton.QuitDriver();
        }
    }
}