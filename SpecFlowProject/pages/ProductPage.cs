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
using SpecFlowProject.pages;
using SpecFlowProject.service;
using SpecFlowProject.dto;

namespace SpecFlowProject.pages
{
    public class ProductPage : Abstract_page
    {
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ProductName']")]
        public IWebElement productName;
        [FindsBy(How = How.XPath, Using = "//select[@id='CategoryId']")]
        public IWebElement categoryId;
        [FindsBy(How = How.XPath, Using = "//select[@id='SupplierId']")]
        public IWebElement suppliersId;
        [FindsBy(How = How.XPath, Using = "//input[@id='UnitPrice']")]
        public IWebElement unitPrice;
        [FindsBy(How = How.XPath, Using = "//input[@id='QuantityPerUnit']")]
        public IWebElement quantityPerUnit;
        [FindsBy(How = How.XPath, Using = "//input[@id='UnitsInStock']")]
        public IWebElement unitInStock;
        [FindsBy(How = How.XPath, Using = "//input[@id='UnitsOnOrder']")]
        public IWebElement unitsOnOrder;
        [FindsBy(How = How.XPath, Using = "//input[@id='ReorderLevel']")]
        public IWebElement reorderLevel;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement buttonSubmit;

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
