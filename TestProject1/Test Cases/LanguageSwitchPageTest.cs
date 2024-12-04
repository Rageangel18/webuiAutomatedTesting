using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;
using FluentAssertions;
using Serilog;

namespace WebUi_automated_testing.Test_Cases
{
    public class LanguageSwitcherTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public LanguageSwitcherTest()
        {
            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: LanguageSwitcherTest");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [Fact]
        public void VerifyLanguageChangeToLithuanian()
        {
            var testData = new TestDataBuilder()
                .WithUrl("https://en.ehu.lt/")
                .WithLanguageLinkText("LT")
                .WithExpectedUrlContains("https://lt.ehu.lt/")
                .WithExpectedHeader("Kodėl EHU?\r\nKas daro EHU unikaliu?")
                .Build();

            Log.Information("Navigating to URL: {Url}", testData.Url);
            _driver.Navigate().GoToUrl(testData.Url);

            var languageSwitcherPage = new LanguageSwitcherPage(_driver);

            Log.Information("Switching to Lithuanian language.");
            languageSwitcherPage.SwitchToLithuanian();

            Log.Information("Verifying the URL contains: {ExpectedUrl}", testData.ExpectedUrlContains);
            _driver.Url.Should().Contain(testData.ExpectedUrlContains, "because the page URL should contain the Lithuanian version.");

            Log.Information("Verifying the header contains: {ExpectedHeader}", testData.ExpectedHeader);
            languageSwitcherPage.GetCurrentHeader().Should().Contain(testData.ExpectedHeader, "because the header should contain the expected Lithuanian text.");
        }

        public void Dispose()
        {
            Log.Information("Test completed: LanguageSwitcherTest");
            DriverSingleton.QuitDriver();
        }
    }
}