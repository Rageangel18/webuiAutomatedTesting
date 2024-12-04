using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase2 : IDisposable
    {
        private readonly IWebDriver _driver;

        public TestCase2()
        {
            _driver = DriverSingleton.GetDriver();

        }

        [Theory]
        [InlineData("https://en.ehu.lt/", "study programs", "https://en.ehu.lt/?s=study%20programs", "search-filter__result-count", "results found.")]
        public void SearchPageTest(string url, string searchTerm, string expectedUrl, string resultClass, string expectedText)
        {
            _driver.Navigate().GoToUrl(url);

            var searchUrl = $"{url}?s={Uri.EscapeDataString(searchTerm)}";
            _driver.Navigate().GoToUrl(searchUrl);

            Assert.Equal(expectedUrl, _driver.Url);

            var searchPage = new SearchPage(_driver);
            Assert.Contains(expectedText, searchPage.SearchResultCount(resultClass).Text);
        }

        public void Dispose()
        {
            DriverSingleton.QuitDriver();
        }
    }
}