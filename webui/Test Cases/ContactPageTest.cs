using NUnit.Framework;
using OpenQA.Selenium;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using FluentAssertions;
using Serilog;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    [Parallelizable]
    [Category("ContactPage")]
    public class ContactPageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {

            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: ContactPageTests");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [TestCase("https://en.ehu.lt/contact/", "franciskscarynacr@gmail.com")]
        [TestCase("https://en.ehu.lt/contact/", "+370 68 771365")]
        [TestCase("https://en.ehu.lt/contact/", "+375 29 5781488")]
        public void VerifyContactInfo(string url, string expectedText)
        {
            Log.Information("Navigating to: {Url}", url);

            var contactPage = new ContactPage(_driver);
            contactPage.NavigateTo(url);

            Log.Information("Verifying if expected contact info '{ExpectedText}' is present.", expectedText);

            contactPage.IsTextPresent(expectedText).Should().BeTrue("because the contact information should be present on the page");

            Log.Information("Test passed for URL: {Url}", url);
        }

        [TearDown]
        public void TearDown()
        {
            Log.Information("Test completed: ContactPageTests");
            DriverSingleton.QuitDriver();
        }
    }
}