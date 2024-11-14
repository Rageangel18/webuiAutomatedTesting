using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    public class TestCase3
    {
        private IWebDriver? _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void VerifyLanguageChangeToLithuanian()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");

            IWebElement languageSwitcher = _driver.FindElement(By.CssSelector(".language-switcher"));
            languageSwitcher.Click();
            IWebElement lithuanianOption = _driver.FindElement(By.LinkText("LT"));
            lithuanianOption.Click();

            Assert.That(_driver.Url, Does.Contain("https://lt.ehu.lt/"));

            IWebElement header = _driver.FindElement(By.TagName("h1"));
            Assert.That(header.Text, Does.Contain("Kodėl EHU?\r\nKas daro EHU unikaliu?"));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
