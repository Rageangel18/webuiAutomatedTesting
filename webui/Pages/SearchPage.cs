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

        public void Search(string searchTerm)
        {
            string searchUrl = $"https://en.ehu.lt/?s={Uri.EscapeDataString(searchTerm)}";
            _driver.Navigate().GoToUrl(searchUrl);
        }

        public string GetResultText(string resultClass)
        {
            return _driver.FindElement(By.ClassName(resultClass)).Text;
        }
    }
}