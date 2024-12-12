using OpenQA.Selenium;

namespace WebUi_automated_testing.PageObjects
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void PerformSearch(string searchTerm)
        {
            var searchBox = _driver.FindElement(By.Name("s"));
            searchBox.Clear();
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();
        }

        public string GetResultCountText(string resultClass)
        {
            var resultElement = _driver.FindElement(By.ClassName(resultClass));
            return resultElement.Text;
        }
    }
}