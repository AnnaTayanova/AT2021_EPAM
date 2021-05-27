using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Selenium_WD_Framework.pages;
using Selenium_WD_Framework.service;
using Selenium_WD_Framework.dto;

namespace Selenium_WD_Framework.pages
{
    class ProductPage : Abstract_page
    {
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ProductName']")]
        private IWebElement productName;
        [FindsBy(How = How.XPath, Using = "//select[@id='CategoryId']")]
        private IWebElement categoryId;
        [FindsBy(How = How.XPath, Using = "//select[@id='SupplierId']")]
        private IWebElement suppliersId;
        [FindsBy(How = How.XPath, Using = "//input[@id='UnitPrice']")]
        private IWebElement unitPrice;
        [FindsBy(How = How.XPath, Using = "//input[@id='QuantityPerUnit']")]
        private IWebElement quantityPerUnit;
        [FindsBy(How = How.XPath, Using = "//input[@id='UnitsInStock']")]
        private IWebElement unitInStock;
        [FindsBy(How = How.XPath, Using = "//input[@id='UnitsOnOrder']")]
        private IWebElement unitsOnOrder;
        [FindsBy(How = How.XPath, Using = "//input[@id='ReorderLevel']")]
        private IWebElement reorderLevel;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement buttonSubmit;

        public All_products_page ExecuteCreateProduct()
        {
            Product product = new Product();
            SelectElement selectCategoryId = new SelectElement(categoryId);
            SelectElement selectSuppliersId = new SelectElement(suppliersId);
            new Actions(driver).SendKeys(productName, product.ProductName).Build().Perform();
            selectCategoryId.SelectByText(product.Category);
            selectSuppliersId.SelectByText(product.Supplier);
            new Actions(driver).SendKeys(unitPrice, product.UnitPrice).Build().Perform();
            new Actions(driver).SendKeys(quantityPerUnit, product.QuanityPerUnit).Build().Perform();
            new Actions(driver).SendKeys(unitInStock, product.UnitsInStock).Build().Perform();
            new Actions(driver).SendKeys(unitsOnOrder, product.UnitsOnOrder).Build().Perform();
            new Actions(driver).SendKeys(reorderLevel, product.ReorderLevel).Build().Perform();
            new Actions(driver).Click(buttonSubmit).Build().Perform();
            return new All_products_page(driver);
        }
    }
}
