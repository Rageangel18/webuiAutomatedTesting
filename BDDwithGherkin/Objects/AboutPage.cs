using OpenQA.Selenium;

namespace WebUi_automated_testing.PageObjects
{
    public class AboutPage
    {
        private readonly IWebDriver _driver;

        public AboutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAbout()
        {
            var aboutLink = _driver.FindElement(By.LinkText("About"));
            aboutLink.Click();
        }
    }
}