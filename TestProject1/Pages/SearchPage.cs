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

        public IWebElement SearchResultCount(string className)
        {
            return _driver.FindElement(By.ClassName(className));
        }
    }
}