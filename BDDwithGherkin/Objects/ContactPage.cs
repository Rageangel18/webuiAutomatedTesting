using OpenQA.Selenium;

namespace WebUi_automated_testing.PageObjects
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPageSource()
        {
            return _driver.PageSource;
        }
    }
}