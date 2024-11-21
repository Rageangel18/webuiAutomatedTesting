using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase4 : IDisposable
    {
        private IWebDriver _driver;

        public TestCase4()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Theory]
        [InlineData("franciskscarynacr@gmail.com")]
        [InlineData("+370 68 771365")]
        [InlineData("+375 29 5781488")]
        public void Test4(string expectedText)
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");
            Assert.Contains(expectedText, _driver.PageSource, StringComparison.OrdinalIgnoreCase);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}