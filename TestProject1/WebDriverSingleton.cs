using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebUi_automated_testing.Utilities
{
    public class DriverSingleton
    {
        private static ThreadLocal<IWebDriver> _driverThreadLocal = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            if (_driverThreadLocal.Value == null)
            {
                _driverThreadLocal.Value = new ChromeDriver();
            }
            return _driverThreadLocal.Value;
        }

        public static void QuitDriver()
        {
            if (_driverThreadLocal.Value != null)
            {
                _driverThreadLocal.Value.Quit();
                _driverThreadLocal.Value = null;
            }
        }
    }
}