using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;

namespace WebUi_automated_testing.Test_Cases
{
    public class LanguageSwitcherTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public LanguageSwitcherTest()
        {
            _driver = DriverSingleton.GetDriver();

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

            _driver.Navigate().GoToUrl(testData.Url);

            var languageSwitcherPage = new LanguageSwitcherPage(_driver);
            languageSwitcherPage.SwitchToLithuanian();

            Assert.Contains(testData.ExpectedUrlContains, _driver.Url);
            Assert.Contains(testData.ExpectedHeader, languageSwitcherPage.GetCurrentHeader());
        }

        public void Dispose()
        {
            DriverSingleton.QuitDriver();
        }
    }
}