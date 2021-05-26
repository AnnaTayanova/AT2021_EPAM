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
    class Home_page: Abstract_page
    {
        
        public Home_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'All Products')]")]
        public IWebElement allProducts;
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")]
        public IWebElement logout;

        public All_products_page ExecuteAllProducts()
        {
            new Actions(driver).Click(allProducts).Build().Perform();
            return new All_products_page(driver);
        }

        public Login_page ExecuteLogout()
        {
            logout.Click();
            return new Login_page(driver);
        }
    }
}
