using EaFramework.Config;
using EaFramework.Driver;
using OpenQA.Selenium;

namespace EaApplicationTestNunit
{
    public class Tests
    {
        private IDriverFixture _driverFixture;

        [SetUp]
        public void Setup()
        {
            var testSettings = new TestSettings()
            {
                ApplicationUrl = "http://localhost:33084/",
                Browser = BrowserType.Chrome,
                TimeoutInterval = 30
            };
            _driverFixture = new DriverFixture(testSettings);
        }

        [Test]
        public void Test1()
        {
            _driverFixture.Driver.FindElement(By.LinkText("Product")).Click();
            _driverFixture.Driver.FindElement(By.LinkText("Create")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            _driverFixture.Driver.Quit();
        }
    }
}