using Xunit;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;

namespace WebUi_automated_testing.Test_Cases
{
    public class TestCase1 : IDisposable
    {
        private readonly IWebDriver _driver;

        public TestCase1()
        {
            _driver = DriverSingleton.GetDriver();

        }

        [Fact]
        public void AboutPageTest()
        {
            var testData = new TestDataBuilder()
                .WithUrl("https://en.ehu.lt/")
                .WithLinkText("About")
                .WithExpectedTitle("About")
                .Build();

            _driver.Navigate().GoToUrl(testData.Url);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);"); // Вкратце. Может быть я дебил, а может со страницей и ее футером реально чтото не так, либо это чисто у меня.
                                                                                                             // Тест не долистывал страницу до кнопки about и фейлился. Поэтому оставил тут заглушку в виде JS скрипта.
            var aboutPage = new AboutPage(_driver);
            aboutPage.ClickAbout();

            Assert.Equal(testData.ExpectedTitle, _driver.Title);
            Assert.Contains(testData.ExpectedTitle, aboutPage.GetHeaderText());
        }

        public void Dispose()
        {
            DriverSingleton.QuitDriver();
        }
    }
}