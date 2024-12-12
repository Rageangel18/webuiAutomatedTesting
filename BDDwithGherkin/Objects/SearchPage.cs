using OpenQA.Selenium;
using System;
using System.Linq;

namespace WebUi_automated_testing.PageObjects
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By SearchButton = By.ClassName("header-search");
        private readonly By SearchBar = By.CssSelector("input.form-control[name='s']");
        private readonly By SearchResults = By.ClassName("search-filter__result-count");


        public void PerformSearch(string searchTerm)
        {
            _driver.FindElement(SearchButton).Click();
            var searchBox = _driver.FindElement(SearchBar);
            searchBox.SendKeys(searchTerm);

            searchBox.SendKeys(Keys.Enter); 
        }


        public bool HasSearchResults(string expectedText) {

            var searchResults = _driver.FindElements(SearchResults);

            return searchResults.Any(result => result.Text.Contains(expectedText, StringComparison.OrdinalIgnoreCase));
        }
    }
}