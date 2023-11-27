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
        private readonly IDriverWait _driver;

        public ProductPage(IDriverWait driver)
        {
            _driver = driver;
        }
        private IWebElement txtName => _driver.FindElement(By.Id("Namex"));
        private IWebElement txtPrice => _driver.FindElement(By.Id("Price"));
        private IWebElement txtDescription => _driver.FindElement(By.Id("Description"));
        private IWebElement ddlProductType => _driver.FindElement(By.Id("ProductType"));
        private IWebElement btnCreate => _driver.FindElement(By.Id("Create"));
        private IWebElement lnkCreate => _driver.FindElement(By.LinkText("Create"));
        private IWebElement tblList => _driver.FindElement(By.CssSelector(".table"));


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
