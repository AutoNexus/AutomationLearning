using EaApplicationTest.Pages;
using EaFramework.Config;
using EaFramework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EaApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private IDriverFixture _driverFixture;
        private IDriverWait _driverWait;
        private HomePage _homePage;
        private ProductPage _productPage;
        public UnitTest1()
        {
            //var testSettings = new TestSettings()
            //{
            //    ApplicationUrl = "http://localhost:33084/",
            //    Browser = BrowserType.Chrome,
            //    TimeoutInterval = 30
            //};
            var testSettings = ConfigReader.ReadConfig();
            _driverFixture = new DriverFixture(testSettings);
            _driverWait = new DriverWait(_driverFixture, testSettings);

            _homePage = new HomePage(_driverWait);
            _productPage = new ProductPage(_driverWait);
        }

        [Fact]
        public void Test1()
        {
            _homePage.ClickProduct();
           // _productPage.PerformClickOnSpecialValue("First Product", "Details");
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(name: "First Product", description: "First Prod Desc", price: "100", productType: "MONITOR");
        }

        [Theory]
        [InlineData("FirstProduct", "new prod desc", "400", "CPU")]
        [InlineData("FirstProduct2", "new prod desc2", "500", "MONITOR")]
        [InlineData("FirstProduct3", "new prod desc3", "600", "PERIPHARALS")]
        [InlineData("FirstProduct4", "new prod desc4", "700", "EXTERNAL")]
        public void Test2(string name, string description, string price, string productType)
        {
            _homePage.ClickProduct();
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(name, description, price, productType);
        }

        //[Fact]
        //public void Test3(string name, string description, string price, string productType)
        //{
        //    _homePage.ClickProduct();
        //    _productPage.ClickCreateButton();
        //    _productPage.CreateProduct(name, description, price, productType);
        //}

        public void Dispose()
        {
            _driverFixture.Driver.Quit();
        }
    }
}