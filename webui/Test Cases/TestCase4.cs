using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [Parallelizable]
    [TestFixture]
    [Category("ContactPage")]
    public class TestCase4
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCase("https://en.ehu.lt/contact/", "franciskscarynacr@gmail.com")]
        [TestCase("https://en.ehu.lt/contact/", "+370 68 771365")]
        [TestCase("https://en.ehu.lt/contact/", "+375 29 5781488")]
        public void Test4(string url, string expectedText)
        {
            _driver.Navigate().GoToUrl(url);
            Assert.That(_driver.PageSource, Does.Contain(expectedText));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}