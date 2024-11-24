﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Test_Cases
{
    [Parallelizable]
    [TestFixture]
    [Category("AboutPage")]
    public class TestCase1
    {
        private IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCase("https://en.ehu.lt/", "About", "About")]
        public void Test1(string url, string linkText, string expectedTitle)
        {
            _driver.Navigate().GoToUrl(url);

            IWebElement aboutLink = _driver.FindElement(By.LinkText(linkText));
            aboutLink.Click();

            Assert.That(_driver.Title, Is.EqualTo(expectedTitle));

            IWebElement header = _driver.FindElement(By.TagName("h1"));
            Assert.That(header.Text, Does.Contain(expectedTitle));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}