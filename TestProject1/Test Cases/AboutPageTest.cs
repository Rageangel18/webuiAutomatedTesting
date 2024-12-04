using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;
using FluentAssertions;
using Serilog;

namespace WebUi_automated_testing.Test_Cases
{
    public class AboutPageTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public AboutPageTest()
        {
            LoggerSetup.ConfigureLogger();
            Log.Information("Test started: AboutPageTest");

            _driver = DriverSingleton.GetDriver();
            Log.Information("Driver initialized.");
        }

        [Fact]
        public void AboutPageTestMethod()
        {
            var testData = new TestDataBuilder()
                .WithUrl("https://en.ehu.lt/")
                .WithLinkText("About")
                .WithExpectedTitle("About")
                .Build();

            Log.Information("Navigating to URL: {Url}", testData.Url);
            _driver.Navigate().GoToUrl(testData.Url);

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            var aboutPage = new AboutPage(_driver);


            Log.Information("Clicking the 'About' link on the page.");
            aboutPage.ClickAbout();


            Log.Information("Verifying the page title and header text.");
            _driver.Title.Should().Be(testData.ExpectedTitle, "because the page title should match the expected title.");
            aboutPage.GetHeaderText().Should().Contain(testData.ExpectedTitle, "because the header should contain the expected text.");
        }

        public void Dispose()
        {
            Log.Information("Test completed: AboutPageTest");
            DriverSingleton.QuitDriver();
        }
    }
}