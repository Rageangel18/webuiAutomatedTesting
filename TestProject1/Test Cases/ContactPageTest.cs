using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;
using FluentAssertions;
using Serilog;

namespace WebUi_automated_testing.Test_Cases
{
    public class ContactPageTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public ContactPageTest()
        {
            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: ContactPageTest");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [Theory]
        [InlineData("https://en.ehu.lt/contact/", "franciskscarynacr@gmail.com")]
        [InlineData("https://en.ehu.lt/contact/", "+370 68 771365")]
        [InlineData("https://en.ehu.lt/contact/", "+375 29 5781488")]
        public void ContactPageTestMethod(string url, string expectedText)
        {
            Log.Information("Navigating to URL: {Url}", url);
            _driver.Navigate().GoToUrl(url);

            var contactPage = new ContactPage(_driver);

            Log.Information("Checking if the page source contains the expected text: {ExpectedText}", expectedText);
            contactPage.GetPageSource().Should().Contain(expectedText, $"because the page should contain the text '{expectedText}'");
        }

        public void Dispose()
        {
            Log.Information("Test completed: ContactPageTest");
            DriverSingleton.QuitDriver();
        }
    }
}