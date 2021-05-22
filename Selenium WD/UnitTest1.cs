using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium_WD
{
    public class Tests
    {
        private IWebDriver driver; 

        public void LoginDefault()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id='Password']"));
            IWebElement buttonSubmit = driver.FindElement(By.XPath("//input[@type='submit']"));

            login.Clear();
            login.SendKeys("user");
            password.Clear();
            password.SendKeys("user");
            buttonSubmit.Click();
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        [Test]
        public void Login()
        {
            LoginDefault();
            IWebElement logout = driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
            Assert.IsTrue(driver.PageSource.Contains("Logout"));
        }

        [Test]
        public void Logout()
        {
            LoginDefault();
            IWebElement logout = driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
            logout.Click();
            Assert.IsFalse(driver.PageSource.Contains("Logout"));
        }

        [Test]
        public void AddProduct()
        {
            LoginDefault();
            IWebElement allProducts = driver.FindElement(By.XPath("//a[contains(text(), 'All Products')]"));
            allProducts.Click();
            IWebElement buttonCreateNew1 = driver.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
            buttonCreateNew1.Click();
            IWebElement productName = driver.FindElement(By.XPath("//input[@id='ProductName']"));
            IWebElement category = driver.FindElement(By.XPath("//select[@id='CategoryId']"));
            IWebElement suppliers = driver.FindElement(By.XPath("//select[@id='SupplierId']"));
            IWebElement unitPrice = driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
            IWebElement quantityPerUnit = driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
            IWebElement unitsInStock = driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
            IWebElement unitsOnOrder = driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
            IWebElement reorderLevel = driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
            IWebElement buttonSubmit = driver.FindElement(By.XPath("//input[@type='submit']"));

            productName.SendKeys("Chocolate cupcake with cherry");
            new SelectElement(driver.FindElement(By.XPath("//select[@id='CategoryId']"))).SelectByText("Confections");
            driver.FindElement(By.XPath("//select[@id='CategoryId']")).Click();
            new SelectElement(driver.FindElement(By.Id("SupplierId"))).SelectByText("Pavlova, Ltd.");
            driver.FindElement(By.XPath("//select[@id='SupplierId']")).Click();
            unitPrice.SendKeys("15");
            quantityPerUnit.SendKeys("10 - 150 g boxes");
            unitsInStock.SendKeys("20");
            unitsOnOrder.SendKeys("0");
            reorderLevel.SendKeys("5");
            buttonSubmit.Click();

            IWebElement buttonCreateNew2 = driver.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
            Assert.AreEqual("Create new", buttonCreateNew2.Text);
        }

        [Test]
        public void ViewProduct()
        {
            LoginDefault();
            IWebElement allProducts = driver.FindElement(By.XPath("//a[contains(text(), 'All Products')]"));
            allProducts.Click();
            IWebElement selectedProduct = driver.FindElement(By.XPath("//a[contains(text(),'Chocolate cupcake with cherry')]"));
            selectedProduct.Click();

            IWebElement productName = driver.FindElement(By.XPath("//input[@id='ProductName']"));
            Assert.AreEqual("Chocolate cupcake with cherry", productName.GetAttribute("value"));

            IWebElement category = driver.FindElement(By.XPath("//select[@id='CategoryId']"));
            Assert.IsTrue(category.Text.Contains("Confections"));

            IWebElement suppliers = driver.FindElement(By.XPath("//select[@id='SupplierId']"));
            Assert.IsTrue(suppliers.Text.Contains("Pavlova, Ltd."));

            IWebElement unitPrice = driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
            Assert.AreEqual("15,0000", unitPrice.GetAttribute("value"));

            IWebElement quantityPerUnit = driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
            Assert.AreEqual("10 - 150 g boxes", quantityPerUnit.GetAttribute("value"));

            IWebElement unitsInStock = driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
            Assert.AreEqual("20", unitsInStock.GetAttribute("value"));

            IWebElement unitsOnOrder = driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
            Assert.AreEqual("0", unitsOnOrder.GetAttribute("value"));

            IWebElement reorderLevel = driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
            Assert.AreEqual("5", reorderLevel.GetAttribute("value"));
        }

        [Test]
        public void DeleteProduct()
        {
            LoginDefault();
            IWebElement allProducts = driver.FindElement(By.XPath("//a[contains(text(), 'All Products')]"));
            allProducts.Click();
            driver.FindElement(By.XPath("//a[contains(@href,'/Product/Remove?ProductId=94')]")).Click();
            driver.SwitchTo().Alert().Accept();
            Assert.IsFalse(driver.PageSource.Contains("Chocolate cupcake with cherry"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}