using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase3 : IDisposable
    {
        private readonly IWebDriver _driver;

        public TestCase3()
        {
            _driver = DriverSingleton.GetDriver();

        }

        [Theory]
        [InlineData("https://en.ehu.lt/contact/", "franciskscarynacr@gmail.com")]
        [InlineData("https://en.ehu.lt/contact/", "+370 68 771365")]
        [InlineData("https://en.ehu.lt/contact/", "+375 29 5781488")]
        public void ContactPageTest(string url, string expectedText)
        {
            _driver.Navigate().GoToUrl(url);

            var contactPage = new ContactPage(_driver);
            Assert.Contains(expectedText, contactPage.GetPageSource());
        }

        public void Dispose()
        {
            DriverSingleton.QuitDriver();
        }
    }
}