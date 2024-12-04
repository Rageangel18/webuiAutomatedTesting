using NUnit.Framework;
using OpenQA.Selenium;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;

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
            _driver = DriverSingleton.GetDriver();
        }

        [TestCase("study programs", "https://en.ehu.lt/?s=study%20programs", "search-filter__result-count", "results found.")]
        public void VerifySearchResults(string searchTerm, string expectedUrl, string resultClass, string expectedText)
        {
            var searchPage = new SearchPage(_driver);
            searchPage.Search(searchTerm);

            Assert.That(_driver.Url, Is.EqualTo(expectedUrl));
            Assert.That(searchPage.GetResultText(resultClass), Does.Contain(expectedText));
        }

        [TearDown]
        public void TearDown()
        {
            DriverSingleton.QuitDriver();
        }
    }
}