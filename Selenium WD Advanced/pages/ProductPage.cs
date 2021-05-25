using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using Selenium_WD_Advanced.pages;

namespace Selenium_WD_Advanced.pages
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
        private IWebElement initPrice;
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
            SelectElement selectCategoryId = new SelectElement(categoryId);
            SelectElement selectSuppliersId = new SelectElement(suppliersId);
            productName.SendKeys("Chocolate cupcake with cherry");
            selectCategoryId.SelectByText("Confections");
            selectSuppliersId.SelectByText("Pavlova, Ltd.");
            initPrice.SendKeys("15");
            quantityPerUnit.SendKeys("10 - 150 g boxes");
            unitInStock.SendKeys("20");
            unitsOnOrder.SendKeys("0");
            reorderLevel.SendKeys("5");
            new Actions(driver).Click(buttonSubmit).Build().Perform();
            return new All_products_page(driver);
        }
    }
}
