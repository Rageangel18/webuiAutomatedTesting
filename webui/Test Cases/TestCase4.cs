using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    public class TestCase4
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test4()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");

            string expectedEmail = "franciskscarynacr@gmail.com";
            Assert.That(_driver.PageSource, Does.Contain(expectedEmail), $"email not found");

            string expectedPhoneLT = "+370 68 771365";
            Assert.That(_driver.PageSource, Does.Contain(expectedPhoneLT), $"LT phone number not found");

            string expectedPhoneBY = "+375 29 5781488";
            Assert.That(_driver.PageSource, Does.Contain(expectedPhoneBY), $"BY phone number not found");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
