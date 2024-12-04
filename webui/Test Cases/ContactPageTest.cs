using NUnit.Framework;
using OpenQA.Selenium;
using WebUi_automated_testing.PageObjects;
using WebUi_automated_testing.Utilities;

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
            _driver = DriverSingleton.GetDriver();
        }

        [TestCase("https://en.ehu.lt/contact/", "franciskscarynacr@gmail.com")]
        [TestCase("https://en.ehu.lt/contact/", "+370 68 771365")]
        [TestCase("https://en.ehu.lt/contact/", "+375 29 5781488")]
        public void VerifyContactInfo(string url, string expectedText)
        {
            var contactPage = new ContactPage(_driver);
            contactPage.NavigateTo(url);

            Assert.That(contactPage.IsTextPresent(expectedText));
        }

        [TearDown]
        public void TearDown()
        {
            DriverSingleton.QuitDriver();
        }
    }
}