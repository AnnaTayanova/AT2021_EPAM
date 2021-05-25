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

namespace Selenium_WD_Advanced
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        [Test]
        public void Login()
        {
            Login_page login = new Login_page(driver);
            Home_page home = login.ExecuteLogin();
            Assert.AreEqual("Logout", home.logout.Text);
        }

        [Test]
        public void Logout()
        {
            Login_page login = new Login_page(driver);
            Home_page home = login.ExecuteLogin();
            Login_page logout = home.ExecuteLogout();
            Assert.IsFalse(driver.PageSource.Contains("Logout"));
        }

        [Test]
        public void AddProduct()
        {
            Login_page login = new Login_page(driver);
            Home_page home = login.ExecuteLogin();
            All_products_page allproducts = home.ExecuteAllProducts();
            ProductPage createproduct = allproducts.ExecuteCreate();
            All_products_page allproducts1 = createproduct.ExecuteCreateProduct();
            IWebElement buttonCreateNew = driver.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
            Assert.AreEqual("Create new", buttonCreateNew.Text);
        }

        [Test]
        public void ViewProduct()
        {

            Login_page login = new Login_page(driver);
            Home_page home = login.ExecuteLogin();
            All_products_page allproducts = home.ExecuteAllProducts();
            ProductPage page = allproducts.ViewSelected();
          
            Assert.AreEqual("Chocolate cupcake with cherry", driver.FindElement(By.XPath("//input[@id='ProductName']")).GetAttribute("value"));
            Assert.IsTrue(driver.FindElement(By.XPath("//select[@id='CategoryId']")).Text.Contains("Confections"));
            Assert.IsTrue(driver.FindElement(By.XPath("//select[@id='SupplierId']")).Text.Contains("Pavlova, Ltd."));
            Assert.AreEqual("15,0000", driver.FindElement(By.XPath("//input[@id='UnitPrice']")).GetAttribute("value"));
            Assert.AreEqual("10 - 150 g boxes", driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']")).GetAttribute("value"));
            Assert.AreEqual("20", driver.FindElement(By.XPath("//input[@id='UnitsInStock']")).GetAttribute("value"));
            Assert.AreEqual("0", driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']")).GetAttribute("value"));
            Assert.AreEqual("5", driver.FindElement(By.XPath("//input[@id='ReorderLevel']")).GetAttribute("value"));
        }

        [Test]
        public void DeleteProduct()
        {
            Login_page login = new Login_page(driver);
            Home_page home = login.ExecuteLogin();
            All_products_page allproducts = home.ExecuteAllProducts();
            All_products_page allporoducts1 = allproducts.ExecuteDelete();
            Assert.IsFalse(driver.PageSource.Contains("Chocolate cupcake with cherry"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}