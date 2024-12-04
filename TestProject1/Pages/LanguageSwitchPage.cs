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

        private IWebElement LanguageSwitcher => _driver.FindElement(By.CssSelector(".language-switcher"));
        private IWebElement LithuanianOption => _driver.FindElement(By.LinkText("LT"));
        private IWebElement Header => _driver.FindElement(By.TagName("h1"));

        public void SwitchToLithuanian()
        {
            LanguageSwitcher.Click();
            LithuanianOption.Click();
        }

        public string GetCurrentHeader()
        {
            return Header.Text;
        }
    }
}