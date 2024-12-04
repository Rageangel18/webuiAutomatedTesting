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


        public IWebElement AboutLink => _driver.FindElement(By.LinkText("About"));
        public IWebElement Header => _driver.FindElement(By.TagName("h1"));

        public void ClickAbout()
        {
            AboutLink.Click();
        }

        public string GetHeaderText()
        {
            return Header.Text;
        }
    }
}