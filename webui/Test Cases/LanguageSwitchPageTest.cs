using NUnit.Framework;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;

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
            _driver = DriverSingleton.GetDriver();
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

            _driver.Navigate().GoToUrl(testData.Url);

            var languageSwitcherPage = new LanguageSwitcherPage(_driver);
            languageSwitcherPage.SwitchToLithuanian();

            Assert.That(_driver.Url, Does.Contain(testData.ExpectedUrlContains));
            Assert.That(languageSwitcherPage.GetCurrentHeader(), Does.Contain(testData.ExpectedHeader));
        }

        [TearDown]
        public void TearDown()
        {
            DriverSingleton.QuitDriver();
        }
    }
}