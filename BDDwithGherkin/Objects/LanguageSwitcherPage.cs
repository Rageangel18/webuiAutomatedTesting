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

        private readonly By LanguageSwitchButton = By.CssSelector(".language-switcher");
        private readonly By LithuanianLanguageButton = By.LinkText("LT");


        public void SwitchToLithuanianLanguage()
        {
            _driver.FindElement(LanguageSwitchButton).Click();

            _driver.FindElement(LithuanianLanguageButton).Click();
        }
    }
}