using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase3 : IDisposable
    {
        private IWebDriver? _driver;

        public TestCase3()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Theory]
        [InlineData("https://en.ehu.lt/", "LT", "https://lt.ehu.lt/", "Kodėl EHU?\r\nKas daro EHU unikaliu?")]
        public void VerifyLanguageChangeToLithuanian(string url, string languageLinkText, string expectedUrlContains, string expectedHeader)
        {
            _driver.Navigate().GoToUrl(url);

            IWebElement languageSwitcher = _driver.FindElement(By.CssSelector(".language-switcher"));
            languageSwitcher.Click();
            IWebElement lithuanianOption = _driver.FindElement(By.LinkText(languageLinkText));
            lithuanianOption.Click();

            Assert.Contains(expectedUrlContains, _driver.Url);

            IWebElement header = _driver.FindElement(By.TagName("h1"));
            Assert.Contains(expectedHeader, header.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}