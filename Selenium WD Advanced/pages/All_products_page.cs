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
    class All_products_page: Abstract_page
    {
        public All_products_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create new')]")]
        private IWebElement buttonCreateNew;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Chocolate cupcake with cherry')]")]
        private IWebElement selectedProduct;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Chocolate cupcake with cherry')]/parent::td/following-sibling::td/a[contains(@href, 'Remove')]")]
        private IWebElement deleteProduct;


        public ProductPage ExecuteCreate()
        {
            new Actions(driver).Click(buttonCreateNew).Build().Perform();
            return new ProductPage(driver);
        }

        public All_products_page ExecuteDelete()
        {
            Thread.Sleep(2000);
            deleteProduct.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            return new All_products_page(driver);
        }

        public ProductPage ViewSelected()
        {
            selectedProduct.Click();
            return new ProductPage(driver);
        }
    }
}
