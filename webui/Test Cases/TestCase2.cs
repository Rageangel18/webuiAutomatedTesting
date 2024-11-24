﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [Parallelizable]
    [TestFixture]
    [Category("TestCategory")]
    public class TestCase2
    {
        private IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCase("https://en.ehu.lt/", "study programs", "https://en.ehu.lt/?s=study%20programs", "search-filter__result-count", "results found.")]
        public void Test2(string url, string searchTerm, string expectedUrl, string resultClass, string expectedText)
        {
            _driver.Navigate().GoToUrl(url);

            string searchUrl = $"https://en.ehu.lt/?s={Uri.EscapeDataString(searchTerm)}";
            _driver.Navigate().GoToUrl(searchUrl);

            Assert.That(_driver.Url, Is.EqualTo(expectedUrl));

            IWebElement searchResults = _driver.FindElement(By.ClassName(resultClass));
            Assert.That(searchResults.Text, Does.Contain(expectedText));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}