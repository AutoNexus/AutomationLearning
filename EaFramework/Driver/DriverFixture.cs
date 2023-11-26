using EaFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaFramework.Driver
{
    public class DriverFixture : IDriverFixture
    {
        private readonly TestSettings _testSettings;
        public IWebDriver Driver { get; }
        public DriverFixture(TestSettings testSettings)
        {
            _testSettings = testSettings;
            Driver = GetWebDriver();
            Driver.Navigate().GoToUrl(testSettings.ApplicationUrl);
        }

        public IWebDriver GetWebDriver()
        {
            return _testSettings.Browser switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.IE => new InternetExplorerDriver(),
                BrowserType.Edge => new EdgeDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => throw new NotSupportedException()
            };
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE,
        Edge,
        Safari
    }
}
