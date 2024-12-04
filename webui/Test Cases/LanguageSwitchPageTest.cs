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
    public class LanguageSwitcherTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: VerifyLanguageChangeToLithuanian");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [Test]
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
            Log.Information("Switching to Lithuanian language...");
            languageSwitcherPage.SwitchToLithuanian();

            Log.Information("Verifying the URL contains: {ExpectedUrl}", testData.ExpectedUrlContains);
            _driver.Url.Should().Contain(testData.ExpectedUrlContains, "because the URL should switch to the Lithuanian version.");

            Log.Information("Verifying the header contains: {ExpectedHeader}", testData.ExpectedHeader);
            languageSwitcherPage.GetCurrentHeader().Should().Contain(testData.ExpectedHeader, "because the header should be updated to the Lithuanian version.");

            Log.Information("Test passed: VerifyLanguageChangeToLithuanian");
        }

        [TearDown]
        public void TearDown()
        {
            Log.Information("Test completed: VerifyLanguageChangeToLithuanian");
            DriverSingleton.QuitDriver();
        }
    }
}