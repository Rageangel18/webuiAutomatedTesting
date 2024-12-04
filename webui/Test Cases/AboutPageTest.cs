using NUnit.Framework;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Serilog;
using FluentAssertions;

namespace WebUi_automated_testing.Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class AboutPageTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            LoggerSetup.ConfigureLogger();
            _driver = DriverSingleton.GetDriver();
            Log.Information("Test started");
        }

        [Test]
        public void AboutPageTesting()
        {
            var testData = new TestDataBuilder()
                .WithUrl("https://en.ehu.lt/")
                .WithLinkText("About")
                .WithExpectedTitle("About")
                .Build();

            Log.Information("Navigating to URL: {Url}", testData.Url);
            _driver.Navigate().GoToUrl(testData.Url);

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            Log.Information("Clicking on 'About' link...");
            var aboutPage = new AboutPage(_driver);
            aboutPage.ClickAbout();

            try
            {
                Log.Information("Checking page title...");
                _driver.Title.Should().Be(testData.ExpectedTitle);

                Log.Information("Checking header text...");
                aboutPage.GetHeaderText().Should().Contain(testData.ExpectedTitle);

                Log.Information("Test passed: AboutPageTest");
            }
            catch (Exception ex)
            {
                Log.Error("Test failed: {Message}", ex.Message);
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            DriverSingleton.QuitDriver();
        }
    }
}