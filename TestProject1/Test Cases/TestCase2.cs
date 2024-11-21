using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase2 : IDisposable
    {
        private IWebDriver? _driver;

        public TestCase2()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Theory]
        [InlineData("https://en.ehu.lt/", "study programs", "https://en.ehu.lt/?s=study%20programs", "search-filter__result-count", "results found.")]
        public void Test2(string url, string searchTerm, string expectedUrl, string resultClass, string expectedText)
        {
            _driver.Navigate().GoToUrl(url);

            string searchUrl = $"https://en.ehu.lt/?s={Uri.EscapeDataString(searchTerm)}";
            _driver.Navigate().GoToUrl(searchUrl);

            Assert.Equal(expectedUrl, _driver.Url);

            IWebElement searchResults = _driver.FindElement(By.ClassName(resultClass));
            Assert.Contains(expectedText, searchResults.Text);
        }

        // IDisposable implementation to replace [TearDown]
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}