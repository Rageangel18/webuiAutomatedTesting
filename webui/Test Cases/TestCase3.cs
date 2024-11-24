﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [Parallelizable]
    [TestFixture]
    [Category("TestCategory")]
    public class TestCase3
    {
        private IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCase("https://en.ehu.lt/", "LT", "https://lt.ehu.lt/", "Kodėl EHU?\r\nKas daro EHU unikaliu?")]
        public void VerifyLanguageChangeToLithuanian(string url, string languageLinkText, string expectedUrlContains, string expectedHeader)
        {
            _driver.Navigate().GoToUrl(url);

            IWebElement languageSwitcher = _driver.FindElement(By.CssSelector(".language-switcher"));
            languageSwitcher.Click();
            IWebElement lithuanianOption = _driver.FindElement(By.LinkText(languageLinkText));
            lithuanianOption.Click();

            Assert.That(_driver.Url, Does.Contain(expectedUrlContains));

            IWebElement header = _driver.FindElement(By.TagName("h1"));
            Assert.That(header.Text, Does.Contain(expectedHeader));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}