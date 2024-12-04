using NUnit.Framework;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
            _driver = DriverSingleton.GetDriver();
        }

        [Test]
        public void AboutPageTesting()
        {
            var testData = new TestDataBuilder()
                .WithUrl("https://en.ehu.lt/")
                .WithLinkText("About")
                .WithExpectedTitle("About")
                .Build();

            _driver.Navigate().GoToUrl(testData.Url);


            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);"); // Вкратце. Может быть я дебил, а может со страницей и ее футером реально чтото не так, либо это чисто у меня.
                                                                                                             // Тест не долистывал страницу до кнопки about и фейлился. Поэтому оставил тут заглушку в виде JS скрипта.


            var aboutLink = _driver.FindElement(By.LinkText(testData.LinkText));

            var actions = new Actions(_driver);
            actions.MoveToElement(aboutLink).Click().Perform();

            Assert.That(_driver.Title, Is.EqualTo(testData.ExpectedTitle));
            var aboutPage = new AboutPage(_driver);
            Assert.That(aboutPage.GetHeaderText(), Does.Contain(testData.ExpectedTitle));
        }

        [TearDown]
        public void TearDown()
        {
            DriverSingleton.QuitDriver();
        }
    }
}