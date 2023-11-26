using EaFramework.Config;
using EaFramework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EaApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private IDriverFixture _driverFixture;
        public UnitTest1()
        {
            var testSettings = new TestSettings()
            {
                ApplicationUrl = "http://localhost:33084/",
                Browser = BrowserType.Chrome,
                TimeoutInterval = 30
            };
            _driverFixture = new DriverFixture(testSettings);
        }

        [Fact]
        public void Test1()
        {
            _driverFixture.Driver.FindElement(By.LinkText("Product")).Click();
            _driverFixture.Driver.FindElement(By.LinkText("Create")).Click();
        }

        public void Dispose()
        {
            _driverFixture.Driver.Quit();
        }
    }
}