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

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public bool IsTextPresent(string text)
        {
            return _driver.PageSource.Contains(text);
        }
    }
}