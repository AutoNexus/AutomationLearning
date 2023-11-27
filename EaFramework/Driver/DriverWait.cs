﻿using EaFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaFramework.Driver
{
    public class DriverWait : IDriverWait
    {
        private readonly IDriverFixture _driverFixture;
        private readonly TestSettings _testSettings;
        private readonly Lazy<WebDriverWait> _webDriverWait;
        public DriverWait(IDriverFixture driverFixture, TestSettings testSettings)
        {
            _driverFixture = driverFixture;
            _testSettings = testSettings;
            _webDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
        }

        public IWebElement FindElement(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _driverFixture.Driver.FindElement(elementLocator));
        }

        public IEnumerable<IWebElement> FindElements(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _driverFixture.Driver.FindElements(elementLocator));
        }

        private WebDriverWait GetWaitDriver()
        {
            return new WebDriverWait(_driverFixture.Driver, TimeSpan.FromSeconds(_testSettings.TimeoutInterval ?? 30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(_testSettings.TimeoutInterval ?? 1)
            };
        }
    }
}
