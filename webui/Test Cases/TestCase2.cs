using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    public class TestCase2
    {
        private IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test2()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");

            string searchTerm = "study programs";
            string searchUrl = $"https://en.ehu.lt/?s={Uri.EscapeDataString(searchTerm)}";
            _driver.Navigate().GoToUrl(searchUrl);
            Assert.That(_driver.Url, Is.EqualTo(searchUrl));
            IWebElement searchResults = _driver.FindElement(By.ClassName("search-filter__result-count"));
            Assert.That(searchResults.Text, Does.Contain("results found."));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
