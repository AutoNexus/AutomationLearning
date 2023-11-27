using EaFramework.Driver;
using EaFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaApplicationTest.Pages
{
    public class ProductPage
    {
        private readonly IDriverFixture _driverFixture;

        public ProductPage(IDriverFixture driverFixture)
        {
            _driverFixture = driverFixture;
        }
        private IWebElement txtName => _driverFixture.Driver.FindElement(By.Id("Name"));
        private IWebElement txtPrice => _driverFixture.Driver.FindElement(By.Id("Price"));
        private IWebElement txtDescription => _driverFixture.Driver.FindElement(By.Id("Description"));
        private IWebElement ddlProductType => _driverFixture.Driver.FindElement(By.Id("ProductType"));
        private IWebElement btnCreate => _driverFixture.Driver.FindElement(By.Id("Create"));
        private IWebElement lnkCreate => _driverFixture.Driver.FindElement(By.LinkText("Create"));
        private IWebElement tblList => _driverFixture.Driver.FindElement(By.CssSelector(".table"));


        public void ClickCreateButton() => lnkCreate.Click();

        public void CreateProduct(string name, string price, string description, string productType)
        {
            txtName.SendKeys(name);
            txtPrice.SendKeys(price);
            txtDescription.SendKeys(description);
            ddlProductType.SelectDropDownByText (productType);
            btnCreate.Click();
        }

        public void PerformClickOnSpecialValue(string name, string operation)
        {
            // if (operation == "Details")
            tblList.PerformActionOnCell("5", "Name", name, operation);
            // else(operation == "Delete")
        }
    }
}
