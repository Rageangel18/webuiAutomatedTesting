using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase1 : IDisposable
    {
        private IWebDriver? _driver;

        public TestCase1()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Theory]
        [InlineData("https://en.ehu.lt/", "About", "About")]
        public void Test1(string url, string linkText, string expectedTitle)
        {
            _driver.Navigate().GoToUrl(url);

            IWebElement aboutLink = _driver.FindElement(By.LinkText(linkText));
            aboutLink.Click();

            Assert.Equal(expectedTitle, _driver.Title);

            IWebElement header = _driver.FindElement(By.TagName("h1"));
            Assert.Contains(expectedTitle, header.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}