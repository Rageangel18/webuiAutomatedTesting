using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    public class TestCase1
    {
        private IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }
        [Test]

        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");

            IWebElement aboutLink = _driver.FindElement(By.LinkText("About"));
            aboutLink.Click();

            Assert.That(_driver.Title, Is.EqualTo("About"));

            IWebElement header = _driver.FindElement(By.TagName("h1"));
            Assert.That(header.Text, Does.Contain("About"));
        }

        [TearDown] public void TearDown()
        {
            _driver.Quit();
        }
    }
}
