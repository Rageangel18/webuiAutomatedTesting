using OpenQA.Selenium;

namespace WebUi_automated_testing.PageObjects
{
    public class LanguageSwitcherPage
    {
        private readonly IWebDriver _driver;

        public LanguageSwitcherPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SwitchLanguage(string language)
        {
            var languageLink = _driver.FindElement(By.LinkText(language));
            languageLink.Click();
        }

        public string GetCurrentHeader()
        {
            var headerElement = _driver.FindElement(By.CssSelector("h1"));
            return headerElement.Text;
        }
    }
}